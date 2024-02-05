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
    public class LoginAuthCommandRequest:IRequest<KuyumcuSystemResult<LoginAuthCommandResponse>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
