using KuyumcuAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Entities
{
    public class Customer:PersonEntity
    {
        public decimal Balance { get; set; } //Müşterinin bakiyesi
        public ICollection<Sale>? Sales { get; set; }
    }
}
