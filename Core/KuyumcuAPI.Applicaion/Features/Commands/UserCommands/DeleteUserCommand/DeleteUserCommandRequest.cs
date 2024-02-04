using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.UserCommands.DeleteUserCommand
{
    public record DeleteUserCommandRequest(int userId):IRequest<KuyumcuSystemResult<string>>
    {
    }
}
