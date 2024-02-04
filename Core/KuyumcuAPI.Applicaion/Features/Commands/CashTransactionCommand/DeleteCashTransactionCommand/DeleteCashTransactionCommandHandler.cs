using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.DeleteCashTransactionCommand
{
    public class DeleteCashTransactionCommandHandler : IRequestHandler<DeleteCashTransactionCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly ICashTransactionService cashTransactionService;

        public DeleteCashTransactionCommandHandler(ICashTransactionService cashTransactionService)
        {
            this.cashTransactionService = cashTransactionService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(DeleteCashTransactionCommandRequest request, CancellationToken cancellationToken)
        {
            return await cashTransactionService.DeleteCashTransaction(request);
        }
    }
}
