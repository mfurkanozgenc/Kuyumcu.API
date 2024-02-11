using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductQuery
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, KuyumcuSystemResult<IList<GetAllProductQueryResponse>>>
    {
        private readonly IProductService productService;

        public GetAllProductQueryHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<KuyumcuSystemResult<IList<GetAllProductQueryResponse>>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            return await productService.GetAllProduct(request);
        }
    }
}
