using KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.AddCashTransactionCommand;
using KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.DeleteCashTransactionCommand;
using KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.UpdateCashTransactionCommand;
using KuyumcuAPI.Domain.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Interfaces.Services
{
    public interface ICashTransactionService
    {
        Task<KuyumcuSystemResult<string>> CreateCashTransaction(AddCashTransactionCommandRequest request);
        Task<KuyumcuSystemResult<string>> UpdateCashTransaction(UpdateCashTransactionCommandRequest request);
        Task<KuyumcuSystemResult<string>> DeleteCashTransaction(DeleteCashTransactionCommandRequest request);
    }
}
