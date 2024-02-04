using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.DeleteProductTypeCommand
{
    public class DeleteProductTypeCommandHandler : IRequestHandler<DeleteProductTypeCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IProductTypeService productTypeService;

        public DeleteProductTypeCommandHandler(IProductTypeService productTypeService)
        {
            this.productTypeService = productTypeService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(DeleteProductTypeCommandRequest request, CancellationToken cancellationToken)
        {
            return await productTypeService.DeleteProductType(request);
        }
    }
}
