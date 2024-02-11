using KuyumcuAPI.Application.Features.Commands.CategoryCommands.AddCategoryCommand;
using KuyumcuAPI.Application.Features.Commands.CategoryCommands.DeleteCategoryCommand;
using KuyumcuAPI.Application.Features.Commands.CategoryCommands.UpdateCategoryCommand;
using KuyumcuAPI.Application.Features.Queries.ProductCategoryQueries.GetAllProductCategoryQuery;
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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<KuyumcuSystemResult<string>> CreateCategory(AddCategoryCommandRequest request)
        {
            Category category = new()
            {
                Name = request.Name
            };
            await unitOfWork.GetWriteRepository<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();
            return new()
            {
                ErrorCode = Result.Successful,
                Value = "Başarılı",
                ErrorMessage = category.Id.ToString()
            };
        }

        public async Task<KuyumcuSystemResult<string>> DeleteCategory(DeleteCategoryCommandRequest request)
        {
            var category = await unitOfWork.GetReadRepository<Category>().GetAsync(c => c.Id == request.categoryId);
            if (category == null)
            {
                return new()
                {
                    ErrorCode = Result.Error,
                    ErrorMessage = "Hata",
                    Value = "Kategori bulunamadı"
                };
            }
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            await unitOfWork.GetWriteRepository<Category>().UpdatAsync(category);
            await unitOfWork.SaveAsync();
            return new()
            {
                ErrorCode = Result.Successful,
                ErrorMessage = "Başarılı",
                Value = "Kategori silindi"
            };
        }

        public async Task<KuyumcuSystemResult<IList<GetAllProductCategoryQueryResponse>>> GetAllCategory(GetAllProductCategoryQueryRequest request)
        {
            var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(c => !c.IsDeleted);
            var map=mapper.Map<GetAllProductCategoryQueryResponse,Category>(categories);
            foreach (var category in map) 
            {
                var productCount = await unitOfWork.GetReadRepository<ProductCategory>().CountAsync(p => p.CategoryId == category.Id);
                category.ProductCount= productCount;
            }        
            return new()
            {
                ErrorCode = Result.Successful,
                ErrorMessage = "Tüm Kategoriler",
                Value = map
            };
        }

        public async Task<KuyumcuSystemResult<string>> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            var category = await unitOfWork.GetReadRepository<Category>().GetAsync(c => c.Id == request.Id);
            if (category == null)
            {
                return new()
                {
                    ErrorCode = Result.Error,
                    ErrorMessage = "Hata",
                    Value = "Kategori bulunamadı"
                };
            }
            var map = mapper.Map<Category, UpdateCategoryCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Category>().UpdatAsync(map);
            await unitOfWork.SaveAsync();
            return new()
            {
                ErrorCode = Result.Successful,
                ErrorMessage = "Başarılı",
                Value = category.Id.ToString()
            };

        }
    }
}
