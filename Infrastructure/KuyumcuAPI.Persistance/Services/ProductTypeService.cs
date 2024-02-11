using KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.AddProductTypeCommand;
using KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.DeleteProductTypeCommand;
using KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.UpdateProductTypeCommand;
using KuyumcuAPI.Application.Features.Queries.ProductTypeQueries.GetAllProductTypeQuery;
using KuyumcuAPI.Application.Interfaces.AutoMapper;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using KuyumcuAPI.Domain.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ReturnResult returnResult;

        public ProductTypeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            returnResult = new ReturnResult();
        }
        public async Task<KuyumcuSystemResult<string>> CreateProductType(AddProductTypeCommandRequest request)
        {
            var oldType = await unitOfWork.GetReadRepository<ProductType>().GetAsync(t => t.Name.ToLower() == request.Name.ToLower());
            if(oldType != null)
            {
                return returnResult.ErrorResponse("Aynı isimde kayıt daha önce mevcut");
            }
            if (string.IsNullOrEmpty(request.Name))
            {
                return returnResult.ErrorResponse("Ürün tipi ismi boş olamaz");
            }
            var type = mapper.Map<ProductType, AddProductTypeCommandRequest>(request);
            await unitOfWork.GetWriteRepository<ProductType>().AddAsync(type);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse(type.Id.ToString());
        }

        public async Task<KuyumcuSystemResult<string>> DeleteProductType(DeleteProductTypeCommandRequest request)
        {
            var productType = await unitOfWork.GetReadRepository<ProductType>().GetAsync(t =>t.Id == request.productTypeId);
            if (productType == null)
            {
                return returnResult.ErrorResponse("Ürün tipi bulunamadı");
            }
            productType.DeletedDate = DateTime.Now;
            productType.IsDeleted = true;
            await unitOfWork.GetWriteRepository<ProductType>().UpdatAsync(productType);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse("Ürün tipi silindi");
        }

        public async Task<KuyumcuSystemResult<IList<GetAllProductTypeQueryResponse>>> GetAllProductType(GetAllProductTypeQueryRequest request)
        {
            var productTypes = await unitOfWork.GetReadRepository<ProductType>().GetAllAsync();
            var map=mapper.Map<GetAllProductTypeQueryResponse,ProductType>(productTypes);
            foreach (var productType in map)
            {
                var productCount = await unitOfWork.GetReadRepository<Product>().CountAsync(p => p.ProductTypeId == productType.Id);
                productType.ProductCount = productCount;
            }
            return new()
            {
                ErrorCode = Result.Successful,
                ErrorMessage = "Tüm ürün tipleri",
                Value = map
            };
        }

        public async Task<KuyumcuSystemResult<string>> UpdateProductType(UpdateProductTypeCommandRequest request)
        {
            var productType = await unitOfWork.GetReadRepository<ProductType>().GetAsync(t => t.Id == request.Id);
            if (productType == null)
            {
                return returnResult.ErrorResponse("Ürün tipi bulunamadı");
            }
            var oldType = await unitOfWork.GetReadRepository<ProductType>().GetAsync(t => t.Name.ToLower() == request.Name.ToLower() && t.Id!=request.Id);
            if (oldType != null)
            {
                return returnResult.ErrorResponse("Aynı isimde kayıt daha önce mevcut");
            }
            if (string.IsNullOrEmpty(request.Name))
            {
                return returnResult.ErrorResponse("Ürün tipi ismi boş olamaz");
            }
            var type = mapper.Map<ProductType, UpdateProductTypeCommandRequest>(request);
            await unitOfWork.GetWriteRepository<ProductType>().UpdatAsync(type);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse(type.Id.ToString());
        }
    }
}
