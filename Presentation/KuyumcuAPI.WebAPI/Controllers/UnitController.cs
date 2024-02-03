using KuyumcuAPI.Application.Features.Commands.UnitCommands.AddUnitCommand;
using KuyumcuAPI.Application.Features.Commands.UnitCommands.DeleteUnitCommand;
using KuyumcuAPI.Application.Features.Commands.UnitCommands.UpdateUnitCommand;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KuyumcuAPI.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IMediator mediator;

        public UnitController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUnit(AddUnitCommandRequest request)
        {
            var result= await this.mediator.Send(request);
            if(result.ErrorCode==Result.Successful) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUnit(UpdateUnitCommandRequest request)
        {
            var result = await this.mediator.Send(request);
            if (result.ErrorCode == Result.Successful) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUnit([Required] int unitId)
        {
            var result = await this.mediator.Send(new DeleteUnitCommandRequest(unitId));
            if (result.ErrorCode == Result.Successful) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
