using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.CustomerQueries.GetAllCustomerQuery
{
    public record GetAllCustomerQueryRequest(int companyId):IRequest<KuyumcuSystemResult<IList<GetAllCustomerQueryResponse>>>
    {
    }
}
