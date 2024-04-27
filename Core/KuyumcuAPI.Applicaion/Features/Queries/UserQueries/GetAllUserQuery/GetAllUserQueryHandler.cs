using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.UserQueries.GetAllUserQuery
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, KuyumcuSystemResult<IList<GetAllUserQueryResponse>>>
    {
        private readonly IUserService userService;

        public GetAllUserQueryHandler(IUserService userService)
        { 
            this.userService = userService;
        }
        public async Task<KuyumcuSystemResult<IList<GetAllUserQueryResponse>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            return await userService.GetAllUser(request);
        }
    }
}
