using KuyumcuAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.CashTransactionQueries.GetAllCashTransactionQuery
{
    public class GetAllCashTransactionQueryResponse
    {
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public CashTransactionType CashTransactionType { get; set; }
    }
}
