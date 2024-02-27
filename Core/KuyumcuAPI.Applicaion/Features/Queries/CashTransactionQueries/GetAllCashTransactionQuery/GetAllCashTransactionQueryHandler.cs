using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.CashTransactionQueries.GetAllCashTransactionQuery
{
    public class GetAllCashTransactionQueryHandler : IRequestHandler<GetAllCashTransactionQueryRequest, KuyumcuSystemResult<IList<GetAllCashTransactionQueryResponse>>>
    {
        private readonly ICashTransactionService cashTransactionService;

        public GetAllCashTransactionQueryHandler(ICashTransactionService cashTransactionService)
        {
            this.cashTransactionService = cashTransactionService;
        }
        public async Task<KuyumcuSystemResult<IList<GetAllCashTransactionQueryResponse>>> Handle(GetAllCashTransactionQueryRequest request, CancellationToken cancellationToken)
        {
            return await cashTransactionService.GetAllCashTransactions(request);
        }
    }
}
