using KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.AddCashTransactionCommand;
using KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.DeleteCashTransactionCommand;
using KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.UpdateCashTransactionCommand;
using KuyumcuAPI.Application.Features.Commands.CategoryCommands.AddCategoryCommand;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KuyumcuAPI.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CashTransactionController : ControllerBase
    {
        private readonly IMediator mediator;

        public CashTransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCashTransaction(AddCashTransactionCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.ErrorCode == Result.Successful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCashTransaction(UpdateCashTransactionCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.ErrorCode == Result.Successful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCashTransaction([Required] int cashTransactionId)
        {
            var result = await mediator.Send(new DeleteCashTransactionCommandRequest(cashTransactionId));
            if (result.ErrorCode == Result.Successful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
