using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductCommands.UpdateProductCommand
{
    public class UpdateProductCommandRequest:IRequest<KuyumcuSystemResult<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public int PurchaseCurrency { get; set; }
        public int SalesCurrency { get; set; }
        public int ProductTypeId { get; set; }
        public decimal Cost { get; set; } // Burası ön yüzden de gönderilebilir ya da apiden de hesaplanabilir
        public decimal Count { get; set; }
        public int UnitId { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
