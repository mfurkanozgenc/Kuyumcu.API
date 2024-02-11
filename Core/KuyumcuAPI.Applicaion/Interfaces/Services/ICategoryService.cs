using KuyumcuAPI.Application.Features.Commands.CategoryCommands.AddCategoryCommand;
using KuyumcuAPI.Application.Features.Commands.CategoryCommands.DeleteCategoryCommand;
using KuyumcuAPI.Application.Features.Commands.CategoryCommands.UpdateCategoryCommand;
using KuyumcuAPI.Application.Features.Queries.ProductCategoryQueries.GetAllProductCategoryQuery;
using KuyumcuAPI.Domain.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<KuyumcuSystemResult<string>> CreateCategory(AddCategoryCommandRequest request);
        Task<KuyumcuSystemResult<string>> UpdateCategory(UpdateCategoryCommandRequest request);
        Task<KuyumcuSystemResult<string>> DeleteCategory(DeleteCategoryCommandRequest request);
        Task<KuyumcuSystemResult<IList<GetAllProductCategoryQueryResponse>>> GetAllCategory(GetAllProductCategoryQueryRequest request);
    }
}
