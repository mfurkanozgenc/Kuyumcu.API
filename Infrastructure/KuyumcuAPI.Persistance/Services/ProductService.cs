using Azure.Core;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.AddProductCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.DeleteProductCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.UpdateProductCommand;
using KuyumcuAPI.Application.Interfaces.AutoMapper;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ReturnResult returnResult;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.returnResult = new ReturnResult();
        }
        public async Task<KuyumcuSystemResult<string>> CreateProduct(AddProductCommandRequest request)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Name == request.Name || p.Barcode == request.Barcode || p.Code == request.Code);
            if (product != null)
            {
                return returnResult.ErrorResponse("Ürün daha önce kayıt edilmiştir.");
            }
            var result=await ProductValidateControl(request, null);
            if (result.ErrorCode == Result.Error)
            {
                return result;
            }

            var map = mapper.Map<Product, AddProductCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Product>().AddAsync(map);
            await unitOfWork.SaveAsync();

            return returnResult.SuccessResponse("Ürün eklendi.");
        }

        public async Task<KuyumcuSystemResult<string>> UpdateProduct(UpdateProductCommandRequest request)
        {
            var oldProduct = await unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Id == request.Id);
            if (oldProduct == null)
            {
                return returnResult.ErrorResponse("Ürün bulunamadı.");
            }
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(p => (p.Name == request.Name || p.Barcode == request.Barcode || p.Code == request.Code) && p.Id!=request.Id);
            if (product != null)
            {
                return returnResult.ErrorResponse("Ürün daha önce kayıt edilmiştir.");
            }

            var result=await ProductValidateControl(null,request);
            if (result.ErrorCode == Result.Error)
            {
                return result;
            }

            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Product>().UpdatAsync(map);
            await unitOfWork.SaveAsync();

            return returnResult.SuccessResponse("Ürün Güncellendi.");
        }

        public async Task<KuyumcuSystemResult<string>> DeleteProduct(DeleteProductCommandRequest request)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Id == request.productId);
            if (product == null)
            {
                return returnResult.ErrorResponse("Ürün bulunamadı");
            }
            product.IsDeleted = true;
            product.DeletedDate=DateTime.Now;
            await unitOfWork.GetWriteRepository<Product>().UpdatAsync(product);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse("Ürün silindi");
        }

        public async Task<KuyumcuSystemResult<string>> ProductValidateControl(AddProductCommandRequest addRequest=null,UpdateProductCommandRequest updateRequest = null)
        {
            AddOrUpdateRequest request = null;
            if(addRequest!= null)
            {
                request = mapper.Map<AddOrUpdateRequest, AddProductCommandRequest>(addRequest);
            }
            if(updateRequest!= null)
            {
                request = mapper.Map<AddOrUpdateRequest, UpdateProductCommandRequest>(updateRequest);
            }
            if (request.PurchasePrice < 0 || request.Count < 0 || request.SalesPrice < 0)
            {
                return returnResult.ErrorResponse("Alış fiyatı, adet veya satış fiyatı negatif olamaz.");
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                return returnResult.ErrorResponse("Ürün adı boş olmamalı.");
            }

            if (request.UnitId <= 0)
            {
                return returnResult.ErrorResponse("Ürün birimi boş olmamalı.");
            }

            if (request.PurchaseCurrency <= 0 || request.SalesCurrency <= 0)
            {
                return returnResult.ErrorResponse("Alış veya satış para birimi seçilmeli.");
            }

            if (request.ProductTypeId <= 0)
            {
                return returnResult.ErrorResponse("Ürün tipi seçilmeli.");
            }

            var unit = await unitOfWork.GetReadRepository<Domain.Entities.Unit>().GetAsync(u => u.Id == request.UnitId);
            if (unit == null)
            {
                return returnResult.ErrorResponse("Ürün birimi bulunamadı.");
            }

            var salesCurrency = await unitOfWork.GetReadRepository<Currency>().GetAsync(c => c.Id == request.SalesCurrency);
            if (salesCurrency == null)
            {
                return returnResult.ErrorResponse("Satış para birimi bulunamadı.");
            }

            var purchaseCurrency = await unitOfWork.GetReadRepository<Currency>().GetAsync(c => c.Id == request.PurchaseCurrency);
            if (purchaseCurrency == null)
            {
                return returnResult.ErrorResponse("Alış para birimi bulunamadı.");
            }

            var productType = await unitOfWork.GetReadRepository<ProductType>().GetAsync(t => t.Id == request.ProductTypeId);
            if (productType == null)
            {
                return returnResult.ErrorResponse("Ürün tipi bulunamadı.");
            }

            if (request.CategoryIds.Count == 0)
            {
                return returnResult.ErrorResponse("En az 1 adet kategori seçilmeli.");
            }

            foreach (var categoryId in request.CategoryIds)
            {
                var category = await unitOfWork.GetReadRepository<Category>().GetAsync(c => c.Id == categoryId);
                if (category == null)
                {
                    return returnResult.ErrorResponse("Kategori bulunamadı.");
                }
            }
            return returnResult.SuccessResponse("Hatasız");
        }

        public class AddOrUpdateRequest
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public string Barcode { get; set; }
            public decimal PurchasePrice { get; set; }
            public decimal SalesPrice { get; set; }
            public int PurchaseCurrency { get; set; }
            public int SalesCurrency { get; set; }
            public int ProductTypeId { get; set; }
            public decimal Cost { get; set; } // Burası ön yüzden de gönderilebilir ya da apiden de hesaplanabilir
            public decimal Count { get; set; }
            public int UnitId { get; set; }
            public List<int> CategoryIds { get; set; }
        }
    }
}
