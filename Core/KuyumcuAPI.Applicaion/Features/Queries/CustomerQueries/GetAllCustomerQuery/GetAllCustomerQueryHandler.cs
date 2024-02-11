using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.CustomerQueries.GetAllCustomerQuery
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, KuyumcuSystemResult<IList<GetAllCustomerQueryResponse>>>
    {
        private readonly ICustomerService customerService;

        public GetAllCustomerQueryHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public async Task<KuyumcuSystemResult<IList<GetAllCustomerQueryResponse>>> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            return await customerService.GetAllCustomer(request);
        }
    }
}
