using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.SalesCommand.AddSalesCommand
{
    public class AddSalesCommandHandler : IRequestHandler<AddSalesCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly ISaleService saleService;

        public AddSalesCommandHandler(ISaleService saleService)
        {
            this.saleService = saleService;
        }
        public Task<KuyumcuSystemResult<string>> Handle(AddSalesCommandRequest request, CancellationToken cancellationToken)
        {
            return saleService.CreateSale(request);
        }
    }
}
