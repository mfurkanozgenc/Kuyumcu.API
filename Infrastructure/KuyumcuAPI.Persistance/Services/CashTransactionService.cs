using KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.AddCashTransactionCommand;
using KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.DeleteCashTransactionCommand;
using KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.UpdateCashTransactionCommand;
using KuyumcuAPI.Application.Interfaces.AutoMapper;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance.Services
{
    public class CashTransactionService : ICashTransactionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ReturnResult returnResult;

        public CashTransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            returnResult = new ReturnResult();
        }
        public async Task<KuyumcuSystemResult<string>> CreateCashTransaction(AddCashTransactionCommandRequest request)
        {
            Customer customer = null;
            if (request.CustomerId > 0)
            {
                customer = await unitOfWork.GetReadRepository<Customer>().GetAsync(c => c.Id == request.CustomerId);
                if (customer == null)
                {
                    return returnResult.ErrorResponse("Müşteri bulunamadı");
                }
            }
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(u => u.Id == request.UserId);
            if (user == null)
            {
                return returnResult.ErrorResponse("Kullanıcı bulunamadı");
            }
            var map=mapper.Map<CashTransaction,AddCashTransactionCommandRequest>(request);
            if(customer == null)
            {
                map.CustomerId = null;
            }
            await unitOfWork.GetWriteRepository<CashTransaction>().AddAsync(map);
            await unitOfWork.SaveAsync();
            if (customer != null)
            {
                if (request.CashTransactionType == CashTransactionType.Income) // Müşteri borcunuda bir kısım ödedi
                {
                    customer.Balance -= request.Amount;
                }
                if (request.CashTransactionType == CashTransactionType.Expense) // MÜşteriye borç versiye verildi
                {
                    customer.Balance += request.Amount;
                }
                await unitOfWork.GetWriteRepository<Customer>().UpdatAsync(customer);
                await unitOfWork.SaveAsync();
            }
            return returnResult.SuccessResponse("Kasa işlemi eklendi");
        }

        public async Task<KuyumcuSystemResult<string>> DeleteCashTransaction(DeleteCashTransactionCommandRequest request)
        {
            var cashTransaction = await unitOfWork.GetReadRepository<CashTransaction>().GetAsync(c => c.Id == request.cashTransactionId);
            if (cashTransaction == null)
            {
                return returnResult.ErrorResponse("Kasa işlemi bulunamadı");
            }
            cashTransaction.DeletedDate = DateTime.Now;
            cashTransaction.IsDeleted = true;
            await unitOfWork.GetWriteRepository<CashTransaction>().UpdatAsync(cashTransaction);
            await unitOfWork.SaveAsync();
            if (cashTransaction.CustomerId>0)
            {
                var customer=await unitOfWork.GetReadRepository<Customer>().GetAsync(c=>c.Id==cashTransaction.CustomerId);
                if (cashTransaction.CashTransactionType == CashTransactionType.Income) // Müşteri borcunuda bir kısım ödedi
                {
                    customer.Balance -= cashTransaction.Amount;
                }
                if (cashTransaction.CashTransactionType == CashTransactionType.Expense) // MÜşteriye borç versiye verildi
                {
                    customer.Balance += cashTransaction.Amount;
                }
                await unitOfWork.GetWriteRepository<Customer>().UpdatAsync(customer);
                await unitOfWork.SaveAsync();
            }
            return returnResult.SuccessResponse("Kasa işlemi silindi");
        }

        public async Task<KuyumcuSystemResult<string>> UpdateCashTransaction(UpdateCashTransactionCommandRequest request)
        {
            var cashTransaction = await unitOfWork.GetReadRepository<CashTransaction>().GetAsync(c => c.Id == request.Id);
            if (cashTransaction == null)
            {
                return returnResult.ErrorResponse("Kasa işlemi bulunamadı");
            }
            if (request.CustomerId > 0)
            {
                var customer = await unitOfWork.GetReadRepository<Customer>().GetAsync(c => c.Id == request.CustomerId);
                if (customer == null)
                {
                    return returnResult.ErrorResponse("Müşteri bulunamadı");
                }
            }
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(u => u.Id == request.UserId);
            if (user == null)
            {
                return returnResult.ErrorResponse("Kullanıcı bulunamadı");
            }
            if (cashTransaction.CustomerId != request.CustomerId)
            {
                return returnResult.ErrorResponse("Müşteri değiştriilmez");
            }
            var oldCashtTransaction = cashTransaction;
            var map = mapper.Map<CashTransaction, UpdateCashTransactionCommandRequest>(request);
            await unitOfWork.GetWriteRepository<CashTransaction>().UpdatAsync(map);
            await unitOfWork.SaveAsync();
            if (oldCashtTransaction.CustomerId > 0)
            {
                var customer = await unitOfWork.GetReadRepository<Customer>().GetAsync(c => c.Id == oldCashtTransaction.CustomerId);
                customer.Balance -= oldCashtTransaction.Amount;
                if (cashTransaction.CashTransactionType == CashTransactionType.Income) // Müşteri borcunuda bir kısım ödedi
                {
                    customer.Balance -= request.Amount;
                }
                if (cashTransaction.CashTransactionType == CashTransactionType.Expense) // MÜşteriye borç versiye verildi
                {
                    customer.Balance += request.Amount;
                }
                await unitOfWork.GetWriteRepository<Customer>().UpdatAsync(customer);
                await unitOfWork.SaveAsync();
            }
            return returnResult.SuccessResponse("Kasa işlemi güncellendi");
        }
    }
}
