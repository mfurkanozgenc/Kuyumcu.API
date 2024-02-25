using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductCommands.ChangeProductSalesStatusCommand
{
    public class ChangeProductSalesStatusCommandHandler : IRequestHandler<ChangeProductSalesStatusCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IProductService productService;

        public ChangeProductSalesStatusCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(ChangeProductSalesStatusCommandRequest request, CancellationToken cancellationToken)
        {
            return await productService.ChangeProductSalesStatus(request);
        }
    }
}
