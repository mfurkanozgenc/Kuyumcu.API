using KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.AddProductTypeCommand;
using KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.DeleteProductTypeCommand;
using KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.UpdateProductTypeCommand;
using KuyumcuAPI.Application.Features.Queries.ProductTypeQueries.GetAllProductTypeQuery;
using KuyumcuAPI.Domain.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Interfaces.Services
{
    public interface IProductTypeService
    {
        Task<KuyumcuSystemResult<string>> CreateProductType(AddProductTypeCommandRequest request);
        Task<KuyumcuSystemResult<string>> UpdateProductType(UpdateProductTypeCommandRequest request);
        Task<KuyumcuSystemResult<string>> DeleteProductType(DeleteProductTypeCommandRequest request);
        Task<KuyumcuSystemResult<IList<GetAllProductTypeQueryResponse>>> GetAllProductType(GetAllProductTypeQueryRequest request);
    }
}
