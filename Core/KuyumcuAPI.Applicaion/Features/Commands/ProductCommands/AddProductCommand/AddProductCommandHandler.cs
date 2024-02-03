using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductCommands.AddProductCommand
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IProductService productService;

        public AddProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            return await productService.CreateProduct(request);
        }
    }
}
