using KuyumcuAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Entities
{
    public class Unit:EntityBase
    {
        public string Name { get; set; }
        public bool IsGram { get; set; } // Ağırlık bazlı mı (gram cinsinden girilecek)
        public bool IsCount { get; set; } // Adet bazlı mı
        public ICollection<Product> Products { get; set; }
    }
}
