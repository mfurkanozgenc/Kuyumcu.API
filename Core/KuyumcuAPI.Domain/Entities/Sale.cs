using KuyumcuAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Entities
{
    public class Sale:EntityBase
    {
        ICollection<ProductSales> SalesProducts { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public bool IsPaid { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
