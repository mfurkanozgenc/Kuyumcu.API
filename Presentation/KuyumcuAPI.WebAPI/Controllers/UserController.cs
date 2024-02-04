using KuyumcuAPI.Application.Features.Commands.SalesCommand.AddSalesCommand;
using KuyumcuAPI.Application.Features.Commands.UserCommands.AddUserCommand;
using KuyumcuAPI.Application.Features.Commands.UserCommands.DeleteUserCommand;
using KuyumcuAPI.Application.Features.Commands.UserCommands.UpdateUserCommand;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KuyumcuAPI.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(AddUserCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.ErrorCode == Result.Successful) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.ErrorCode == Result.Successful) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser([Required] int userId)
        {
            var result = await mediator.Send(new DeleteUserCommandRequest(userId));
            if (result.ErrorCode == Result.Successful) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
