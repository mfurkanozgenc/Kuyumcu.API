using KuyumcuAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Entities
{
    public class SalesProduct:EntityBase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal SalesPrice { get; set; }
        ICollection<ProductSales> SalesProducts { get; set; }
    }
}
