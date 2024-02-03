using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductCommands.DeleteProductCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IProductService productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            return await productService.DeleteProduct(request);
        }
    }
}
