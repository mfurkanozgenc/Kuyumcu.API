using KuyumcuAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Entities
{
    public class CashTransaction:EntityBase
    {
        public int? CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public CashTransactionType CashTransactionType { get; set; }
    }
    public enum CashTransactionType
    {
        Income, // Gelir
        Expense // Gider
    }
}
