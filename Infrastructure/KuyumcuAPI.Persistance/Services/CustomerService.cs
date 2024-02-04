using KuyumcuAPI.Application.Features.Commands.CustomerCommands.AddCustomerCommand;
using KuyumcuAPI.Application.Features.Commands.CustomerCommands.DeleteCustomerCommand;
using KuyumcuAPI.Application.Features.Commands.CustomerCommands.UpdateCustomerCommand;
using KuyumcuAPI.Application.Interfaces.AutoMapper;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ReturnResult returnResult;
        public CustomerService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            returnResult = new ReturnResult();
        }
        public async Task<KuyumcuSystemResult<string>> CreateCustomer(AddCustomerCommandRequest request)
        {
            var oldCustomer=await unitOfWork.GetReadRepository<Customer>().GetAsync(c=>c.IdentificationNumber==request.IdentificationNumber || c.PhoneNumber==request.PhoneNumber);
            if(oldCustomer!=null)
            {
                return returnResult.ErrorResponse("Aynı bilgilere ait daha önce müşteri oluşturulmuştur");
            }
            if(string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName))
            {
                return returnResult.ErrorResponse("Müşteri adı ya da soyadı boş olamaz");
            }
            var map=mapper.Map<Customer,AddCustomerCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Customer>().AddAsync(map);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse("Müşteri eklendi");
        }

        public async Task<KuyumcuSystemResult<string>> DeleteCustomer(DeleteCustomerCommandRequest request)
        {
            var customer = await unitOfWork.GetReadRepository<Customer>().GetAsync(c => c.Id == request.customerId);
            if (customer == null)
            {
                return returnResult.ErrorResponse("Müşteri bulunamadı");
            }
            customer.DeletedDate = DateTime.Now;
            customer.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Customer>().UpdatAsync(customer);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse("Müşteri silindi");
        }

        public async Task<KuyumcuSystemResult<string>> UpdateCustomer(UpdateCustomerCommandRequest request)
        {
            var customer = await unitOfWork.GetReadRepository<Customer>().GetAsync(c => c.Id == request.Id);
            if (customer == null)
            {
                return returnResult.ErrorResponse("Müşteri bulunamadı");
            }
            var oldCustomer = await unitOfWork.GetReadRepository<Customer>().GetAsync(c => (c.IdentificationNumber == request.IdentificationNumber || c.PhoneNumber == request.PhoneNumber) && c.Id!=request.Id);
            if (oldCustomer != null)
            {
                return returnResult.ErrorResponse("Aynı bilgilere ait daha önce müşteri oluşturulmuştur");
            }
            if (string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName))
            {
                return returnResult.ErrorResponse("Müşteri adı ya da soyadı boş olamaz");
            }
            var map = mapper.Map<Customer, UpdateCustomerCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Customer>().UpdatAsync(map);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse("Müşteri güncellendi");
        }
    }
}
