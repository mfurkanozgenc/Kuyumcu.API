using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.UserCommands.AddUserCommand
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IUserService userService;

        public AddUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await userService.CreateUser(request);
        }
    }
}
