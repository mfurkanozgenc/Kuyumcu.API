using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CustomerCommands.DeleteCustomerCommand
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly ICustomerService customerService;

        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            return await customerService.DeleteCustomer(request);
        }
    }
}
