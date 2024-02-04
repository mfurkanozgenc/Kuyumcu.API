using KuyumcuAPI.Application.Features.Commands.SalesCommand.AddSalesCommand;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KuyumcuAPI.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IMediator mediator;

        public SaleController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSales(AddSalesCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.ErrorCode == Result.Successful) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
