using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.AddCashTransactionCommand
{
    public class AddCashTransactionCommandHandler : IRequestHandler<AddCashTransactionCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly ICashTransactionService cashTransactionService;

        public AddCashTransactionCommandHandler(ICashTransactionService cashTransactionService)
        {
            this.cashTransactionService = cashTransactionService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(AddCashTransactionCommandRequest request, CancellationToken cancellationToken)
        {
            return await cashTransactionService.CreateCashTransaction(request);
        }
    }
}
