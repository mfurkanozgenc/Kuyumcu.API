using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.AddProductTypeCommand
{
    public class AddProductTypeCommandHandler : IRequestHandler<AddProductTypeCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IProductTypeService productTypeService;

        public AddProductTypeCommandHandler(IProductTypeService productTypeService)
        {
            this.productTypeService = productTypeService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(AddProductTypeCommandRequest request, CancellationToken cancellationToken)
        {
            return await productTypeService.CreateProductType(request);
        }
    }
}
