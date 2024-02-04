using KuyumcuAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Entities
{
    public class ProductSales:EntityBase
    {
        public int SalesId { get; set; }
        public Sale Sales { get; set; }
        public int SalesProductId { get; set; }
        public SalesProduct SalesProduct { get; set; }
    }
}
