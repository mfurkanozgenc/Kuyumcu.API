using KuyumcuAPI.Application.Features.Commands.ProductCommands.AddProductCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.ChangeProductSalesStatusCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.DeleteProductCommand;
using KuyumcuAPI.Application.Features.Commands.ProductCommands.UpdateProductCommand;
using KuyumcuAPI.Application.Features.Queries.CustomerQueries.GetAllCustomerQuery;
using KuyumcuAPI.Application.Features.Queries.ProductCategoryQueries.GetAllProductCategoryQuery;
using KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductQuery;
using KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductWithCategoryQuery;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KuyumcuAPI.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(AddProductCommandRequest request)
        {
            var result=await mediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([Required] int productId)
        {
            var result = await mediator.Send(new DeleteProductCommandRequest(productId));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct([Required] int companyId)
        {
            var result = await mediator.Send(new GetAllProductQueryRequest(companyId));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductWithCategory([Required] int categoryId)
        {
            var result = await mediator.Send(new GetAllProductWithCategoryQueryRequest(categoryId));
            return Ok(result);
        }
        [HttpPatch]
        public async Task<IActionResult> ChangeProductSalesStatus(ChangeProductSalesStatusCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
