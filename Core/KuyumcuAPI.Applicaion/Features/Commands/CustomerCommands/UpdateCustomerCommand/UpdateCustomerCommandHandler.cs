using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CustomerCommands.UpdateCustomerCommand
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly ICustomerService customerService;

        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            return await customerService.UpdateCustomer(request);
        }
    }
}
