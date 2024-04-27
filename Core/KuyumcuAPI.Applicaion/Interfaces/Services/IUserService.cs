using KuyumcuAPI.Application.Features.Commands.UserCommands.AddUserCommand;
using KuyumcuAPI.Application.Features.Commands.UserCommands.DeleteUserCommand;
using KuyumcuAPI.Application.Features.Commands.UserCommands.UpdateUserCommand;
using KuyumcuAPI.Application.Features.Queries.UserQueries.GetAllUserQuery;
using KuyumcuAPI.Domain.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<KuyumcuSystemResult<string>> CreateUser(AddUserCommandRequest request);
        Task<KuyumcuSystemResult<string>> UpdateUser(UpdateUserCommandRequest request);
        Task<KuyumcuSystemResult<string>> DeleteUser(DeleteUserCommandRequest request);
        Task<KuyumcuSystemResult<IList<GetAllUserQueryResponse>>> GetAllUser(GetAllUserQueryRequest request);
    }
}
