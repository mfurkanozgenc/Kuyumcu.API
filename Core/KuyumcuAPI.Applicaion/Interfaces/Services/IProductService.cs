using KuyumcuAPI.Application.Features.Commands.ProductCommands.AddProductCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.ChangeProductSalesStatusCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.DeleteProductCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.UpdateProductCommand;
using KuyumcuAPI.Application.Features.Queries.ProductCategoryQueries.GetAllProductCategoryQuery;
using KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductQuery;
using KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductWithCategoryQuery;
using KuyumcuAPI.Domain.ApiResult;

namespace KuyumcuAPI.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<KuyumcuSystemResult<string>> CreateProduct(AddProductCommandRequest request);
        Task<KuyumcuSystemResult<string>> UpdateProduct(UpdateProductCommandRequest request);
        Task<KuyumcuSystemResult<string>> DeleteProduct(DeleteProductCommandRequest request);
        Task<KuyumcuSystemResult<string>> ChangeProductSalesStatus(ChangeProductSalesStatusCommandRequest request);
        Task<KuyumcuSystemResult<IList<GetAllProductQueryResponse>>> GetAllProduct(GetAllProductQueryRequest request);
        Task<KuyumcuSystemResult<IList<GetAllProductWithCategoryQueryResponse>>> GetAllProductWithCategory(GetAllProductWithCategoryQueryRequest request);
    }
}
