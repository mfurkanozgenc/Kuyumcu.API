﻿using KuyumcuAPI.Application.Features.Commands.CustomerCommands.AddCustomerCommand;
using KuyumcuAPI.Application.Features.Commands.CustomerCommands.DeleteCustomerCommand;
using KuyumcuAPI.Application.Features.Commands.CustomerCommands.UpdateCustomerCommand;
using KuyumcuAPI.Application.Features.Queries.CustomerQueries.GetAllCustomerQuery;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KuyumcuAPI.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(AddCustomerCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([Required] int customerId)
        {
            var result = await mediator.Send(new DeleteCustomerCommandRequest(customerId));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer([Required] int companyId)
        {
            var result = await mediator.Send(new GetAllCustomerQueryRequest(companyId));
            return Ok(result);
        }
    }
}
