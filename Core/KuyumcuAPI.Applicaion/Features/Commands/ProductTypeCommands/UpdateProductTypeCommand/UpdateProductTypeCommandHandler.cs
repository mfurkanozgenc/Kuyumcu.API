using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.UpdateProductTypeCommand
{
    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IProductTypeService productTypeService;

        public UpdateProductTypeCommandHandler(IProductTypeService productTypeService)
        {
            this.productTypeService = productTypeService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(UpdateProductTypeCommandRequest request, CancellationToken cancellationToken)
        {
            return await productTypeService.UpdateProductType(request);
        }
    }
}
