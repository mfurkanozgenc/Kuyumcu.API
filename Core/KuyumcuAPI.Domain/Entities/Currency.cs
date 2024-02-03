using KuyumcuAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Entities
{
    public class Currency:EntityBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
