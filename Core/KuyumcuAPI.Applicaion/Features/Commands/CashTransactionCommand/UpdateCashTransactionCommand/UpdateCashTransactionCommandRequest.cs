using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CashTransactionCommand.UpdateCashTransactionCommand
{
    public class UpdateCashTransactionCommandRequest:IRequest<KuyumcuSystemResult<string>>
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
        public int UserId { get; set; }
        public CashTransactionType CashTransactionType { get; set; }
    }
}
