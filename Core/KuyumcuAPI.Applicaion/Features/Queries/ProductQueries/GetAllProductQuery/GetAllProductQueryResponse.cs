using KuyumcuAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductQuery
{
    public class GetAllProductQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public decimal PurchasePrice { get; set; } 
        public decimal SalesPrice { get; set; } 
        public int PurchaseCurrency { get; set; }
        public int SalesCurrency { get; set; }
        public decimal Cost { get; set; }
        public bool StockStatus { get; set; }
        public decimal Count { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductTypeName { get; set; }
        public bool SalesStatus { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
