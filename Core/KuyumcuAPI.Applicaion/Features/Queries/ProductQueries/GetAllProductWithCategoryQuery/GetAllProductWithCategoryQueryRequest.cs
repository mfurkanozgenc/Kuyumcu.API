using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductWithCategoryQuery
{
    public record GetAllProductWithCategoryQueryRequest(int categoryId):IRequest<KuyumcuSystemResult<IList<GetAllProductWithCategoryQueryResponse>>>
    {
    }
}
