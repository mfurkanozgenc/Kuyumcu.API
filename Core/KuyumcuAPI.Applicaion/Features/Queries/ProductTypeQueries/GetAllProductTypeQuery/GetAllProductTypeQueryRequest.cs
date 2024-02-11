using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.ProductTypeQueries.GetAllProductTypeQuery
{
    public record GetAllProductTypeQueryRequest(int companyId):IRequest<KuyumcuSystemResult<IList<GetAllProductTypeQueryResponse>>>
    {
    }
}
