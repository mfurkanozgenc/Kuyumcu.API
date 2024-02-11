using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.ProductCategoryQueries.GetAllProductCategoryQuery
{
    public class GetAllProductCategoryQueryHandler : IRequestHandler<GetAllProductCategoryQueryRequest, KuyumcuSystemResult<IList<GetAllProductCategoryQueryResponse>>>
    {
        private readonly ICategoryService categoryService;

        public GetAllProductCategoryQueryHandler(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<KuyumcuSystemResult<IList<GetAllProductCategoryQueryResponse>>> Handle(GetAllProductCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            return await categoryService.GetAllCategory(request);
        }
    }
}
