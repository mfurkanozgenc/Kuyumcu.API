using KuyumcuAPI.Application.Features.Commands.ProductCommands.AddProductCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.DeleteProductCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.UpdateProductCommand;
using KuyumcuAPI.Domain.ApiResult;

namespace KuyumcuAPI.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<KuyumcuSystemResult<string>> CreateProduct(AddProductCommandRequest request);
        Task<KuyumcuSystemResult<string>> UpdateProduct(UpdateProductCommandRequest request);
        Task<KuyumcuSystemResult<string>> DeleteProduct(DeleteProductCommandRequest request);
    }
}
