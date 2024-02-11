using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductWithCategoryQuery
{
    public class GetAllProductWithCategoryQueryHandler : IRequestHandler<GetAllProductWithCategoryQueryRequest, KuyumcuSystemResult<IList<GetAllProductWithCategoryQueryResponse>>>
    {
        private readonly IProductService productService;

        public GetAllProductWithCategoryQueryHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<KuyumcuSystemResult<IList<GetAllProductWithCategoryQueryResponse>>> Handle(GetAllProductWithCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            return await productService.GetAllProductWithCategory(request);
        }
    }
}
