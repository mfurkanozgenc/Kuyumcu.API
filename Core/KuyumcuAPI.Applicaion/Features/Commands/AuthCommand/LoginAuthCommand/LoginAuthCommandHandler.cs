using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.AuthCommand.LoginAuthCommand
{
    public class LoginAuthCommandHandler : IRequestHandler<LoginAuthCommandRequest, KuyumcuSystemResult<LoginAuthCommandResponse>>
    {
        private readonly IAuthService authService;

        public LoginAuthCommandHandler(IAuthService authService)
        {
            this.authService = authService;
        }
        public async Task<KuyumcuSystemResult<LoginAuthCommandResponse>> Handle(LoginAuthCommandRequest request, CancellationToken cancellationToken)
        {
            return await authService.Login(request);
        }
    }
}
