using KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.AddProductTypeCommand;
using KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.DeleteProductTypeCommand;
using KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.UpdateProductTypeCommand;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KuyumcuAPI.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductType(AddProductTypeCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.ErrorCode == Result.Successful) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductType(UpdateProductTypeCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.ErrorCode == Result.Successful) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductType([Required] int productTypeId)
        {
            var result = await mediator.Send(new DeleteProductTypeCommandRequest(productTypeId));
            if (result.ErrorCode == Result.Successful) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
