using KuyumcuAPI.Application.Features.Commands.SalesCommand.AddSalesCommand;
using KuyumcuAPI.Application.Interfaces.AutoMapper;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance.Services
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ReturnResult returnResult;

        public SaleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            returnResult = new ReturnResult();
        }
        public async Task<KuyumcuSystemResult<string>> CreateSale(AddSalesCommandRequest request)
        {
            Customer customer = null;
            Decimal productsTotalAmount = 0;
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
            if (request.TotalAmount <= 0)
            {
                return returnResult.ErrorResponse("Toplam Tutarn sıfırdan büyük olmalı");
            }
            foreach (var saleProduct in request.SalesProducts)
            {
                var product = await unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Id == saleProduct.ProductId);
                if (product == null)
                {
                    return returnResult.ErrorResponse("Ürün bulunamadı");
                }
            }
            List<SalesProduct> salesProducst = new List<SalesProduct>();
            foreach (var product in request.SalesProducts)
            {
                SalesProduct p = new()
                {
                    ProductId = product.ProductId,
                    SalesPrice = product.SalePrice,
                };
                salesProducst.Add(p);
                productsTotalAmount += product.SalePrice;
            }
            Sale sale = new()
            {
                UserId = user.Id,
                TotalAmount = request.TotalAmount
            };
            if (request.AmountReceived >= request.TotalAmount)
            {
                sale.IsPaid = true;
            }
            else
            {
                sale.RemainingAmount = sale.TotalAmount - request.AmountReceived;
            }
            if (customer != null)
            {
                sale.CustomerId = customer.Id;
            }
            if (productsTotalAmount != request.TotalAmount)
            {
                return returnResult.ErrorResponse("Ürünlerin toplam tutarı ile genel toplam tutar hatalı");
            }
            await unitOfWork.GetWriteRepository<Sale>().AddAsync(sale);
            await unitOfWork.SaveAsync();
            foreach (var product in salesProducst)
            {
                SalesProduct salesProduct = new()
                {
                    ProductId = product.ProductId,
                    SalesPrice = product.SalesPrice,
                };
                await unitOfWork.GetWriteRepository<SalesProduct>().AddAsync(salesProduct);
                await unitOfWork.SaveAsync();
                ProductSales productSales = new()
                {
                    SalesProductId = salesProduct.Id,
                    SalesId = sale.Id
                };
                await unitOfWork.GetWriteRepository<ProductSales>().AddAsync(productSales);
                await unitOfWork.SaveAsync();
            }
            CashTransaction cashTransaction = new()
            {
                Amount = request.AmountReceived,
                UserId = user.Id,
                Note = request.AmountReceived+ "₺ Ödeme alınmıştır",
                CashTransactionType=CashTransactionType.Sale
            };
            if(customer != null) 
            {
                cashTransaction.CustomerId = customer.Id;
                if (request.AmountReceived < request.TotalAmount)
                {
                    var differenceAmount = request.TotalAmount - request.AmountReceived;
                    customer.Balance += differenceAmount;
                    await unitOfWork.GetWriteRepository<Customer>().UpdatAsync(customer);
                    await unitOfWork.SaveAsync();
                }
            }
            await unitOfWork.GetWriteRepository<CashTransaction>().AddAsync(cashTransaction);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse("Satış işlemi başarılı");

        }
    }
}
