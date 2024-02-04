using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.UserCommands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IUserService userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await userService.UpdateUser(request);
        }
    }
}
