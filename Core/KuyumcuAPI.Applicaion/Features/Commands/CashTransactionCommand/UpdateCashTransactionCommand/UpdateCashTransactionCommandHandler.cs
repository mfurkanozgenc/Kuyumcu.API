using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.UpdateCashTransactionCommand
{
    public class UpdateCashTransactionCommandHandler : IRequestHandler<UpdateCashTransactionCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly ICashTransactionService cashTransactionService;

        public UpdateCashTransactionCommandHandler(ICashTransactionService cashTransactionService)
        {
            this.cashTransactionService = cashTransactionService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(UpdateCashTransactionCommandRequest request, CancellationToken cancellationToken)
        {
            return await cashTransactionService.UpdateCashTransaction(request);
        }
    }
}
