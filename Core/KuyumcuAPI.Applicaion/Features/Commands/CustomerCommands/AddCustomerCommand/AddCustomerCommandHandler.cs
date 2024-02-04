using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CustomerCommands.AddCustomerCommand
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly ICustomerService customerService;

        public AddCustomerCommandHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            return await customerService.CreateCustomer(request);
        }
    }
}
