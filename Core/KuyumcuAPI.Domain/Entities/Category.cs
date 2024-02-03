using KuyumcuAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Entities
{
    public class Category:EntityBase
    {
        public string Name { get; set; }
        ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
