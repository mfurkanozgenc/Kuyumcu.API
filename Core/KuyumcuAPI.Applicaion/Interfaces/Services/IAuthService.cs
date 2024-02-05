using KuyumcuAPI.Application.Features.Commands.AuthCommand.LoginAuthCommand;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<KuyumcuSystemResult<LoginAuthCommandResponse>> Login(LoginAuthCommandRequest request);
    }
}
