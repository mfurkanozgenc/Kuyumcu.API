using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.SalesCommand.AddSalesCommand
{
    public class AddSalesCommandRequest:IRequest<KuyumcuSystemResult<string>>
    {
        public List<SalesWithProduct> SalesProducts { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountReceived { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public decimal Discount { get; set; }
    }
    public class SalesWithProduct
    {
        public int ProductId { get; set; }
        public decimal Count { get; set; }
        public decimal SalePrice { get; set; }
    }
}
