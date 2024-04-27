using KuyumcuAPI.Application.Features.Commands.CategoryCommands.AddCategoryCommand;
using KuyumcuAPI.Application.Features.Commands.CategoryCommands.DeleteCategoryCommand;
using KuyumcuAPI.Application.Features.Commands.CategoryCommands.UpdateCategoryCommand;
using KuyumcuAPI.Application.Features.Queries.CustomerQueries.GetAllCustomerQuery;
using KuyumcuAPI.Application.Features.Queries.ProductCategoryQueries.GetAllProductCategoryQuery;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KuyumcuAPI.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(AddCategoryCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([Required] int categoryId)
        {
            var result = await mediator.Send(new DeleteCategoryCommandRequest(categoryId));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory([Required] int companyId)
        {
            var result = await mediator.Send(new GetAllProductCategoryQueryRequest(companyId));
            return Ok(result);
        }
    }
}
