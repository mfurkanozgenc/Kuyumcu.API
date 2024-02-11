using Azure.Core;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.AddProductCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.DeleteProductCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.UpdateProductCommand;
using KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductQuery;
using KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductWithCategoryQuery;
using KuyumcuAPI.Application.Interfaces.AutoMapper;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

            return returnResult.SuccessResponse(product.Id.ToString());
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

            return returnResult.SuccessResponse(product.Id.ToString());
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

        public async Task<KuyumcuSystemResult<IList<GetAllProductQueryResponse>>> GetAllProduct(GetAllProductQueryRequest request)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(null,t=>t.Include(a=>a.ProductType));
            var map=mapper.Map<GetAllProductQueryResponse,Product>(products);
            foreach (var product in map)
            {
                var productCategoryNames = "";
                var productCategories = await unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(c => c.Id == product.Id);
                foreach (var category in productCategories)
                {
                    var findCategory = await unitOfWork.GetReadRepository<Category>().GetAsync(c => c.Id == category.CategoryId);
                    if (findCategory != null)
                    {
                        productCategoryNames += findCategory.Name+",";
                    }
                }
                if (!string.IsNullOrEmpty(productCategoryNames))
                {
                    productCategoryNames = productCategoryNames.Remove(productCategoryNames.Length - 1);
                }
                product.ProductCategoryName = productCategoryNames;
                var productType=products.SingleOrDefault(p=>p.Id== product.Id);
                product.ProductTypeName = productType.ProductType.Name;
            }
            return new()
            {
                ErrorCode = Result.Successful,
                ErrorMessage = "Tüm Ürünler",
                Value = map
            };
        }

        public async Task<KuyumcuSystemResult<IList<GetAllProductWithCategoryQueryResponse>>> GetAllProductWithCategory(GetAllProductWithCategoryQueryRequest request)
        {
            var productCategories = await unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(pc => !pc.IsDeleted && pc.CategoryId==request.categoryId);
            IList<Product> products = new List<Product>();
            foreach (var category in productCategories)
            {
                var product = await unitOfWork.GetReadRepository<Product>().GetAsync(p => !p.IsDeleted, t => t.Include(a => a.ProductType));
                if(product != null)
                {
                    products.Add(product);
                }
            }
            var map=mapper.Map<GetAllProductWithCategoryQueryResponse, Product>(products);
            foreach (var product in map)
            {
                var productCategoryNames = "";
                var productCategory = await unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(c => c.Id == product.Id);
                foreach (var category in productCategory)
                {
                    var findCategory = await unitOfWork.GetReadRepository<Category>().GetAsync(c => c.Id == category.CategoryId);
                    if (findCategory != null)
                    {
                        productCategoryNames += findCategory.Name + ",";
                    }
                }
                if (!string.IsNullOrEmpty(productCategoryNames))
                {
                    productCategoryNames = productCategoryNames.Remove(productCategoryNames.Length - 1);
                }
                product.ProductCategoryName = productCategoryNames;
                var productType = products.SingleOrDefault(p => p.Id == product.Id);
                product.ProductTypeName = productType.ProductType.Name;
            }
            return new()
            {
                ErrorCode = Result.Successful,
                ErrorMessage = "Kategoriye ait ürünler",
                Value = map
            };
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
