using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductCommands.UpdateProductCommand
{
    public class UpdateProductCommanHandler : IRequestHandler<UpdateProductCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IProductService productService;

        public UpdateProductCommanHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            return await productService.UpdateProduct(request);
        }
    }
}
