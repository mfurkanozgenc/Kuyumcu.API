using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.UserCommands.DeleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IUserService userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await userService.DeleteUser(request);
        }
    }
}
