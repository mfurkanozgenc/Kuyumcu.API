using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.ProductQueries.GetAllProductWithCategoryQuery
{
    public class GetAllProductWithCategoryQueryResponse
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
        public DateTime CreatedDate { get; set; }
    }
}
