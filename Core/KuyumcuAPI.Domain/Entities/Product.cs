using KuyumcuAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Entities
{
    public class Product:EntityBase
    {
        public string Name { get; set; }
        public string? Code { get; set; }
        public string? Barcode { get; set; }
        public decimal? PurchasePrice { get; set; } // Alış Fiyatı
        public decimal? SalesPrice { get; set; } // Satış Fiyatı
        public int? PurchaseCurrency { get; set; } // Alış para birimi
        public int? SalesCurrency { get; set; } // Satış para birimi
        public decimal Cost { get; set; } // Ürün maaliyeti
        public bool StockStatus { get; set; }
        public decimal Count { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
