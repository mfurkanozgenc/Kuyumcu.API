using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductCommands.ChangeProductSalesStatusCommand
{
    public class ChangeProductSalesStatusCommandRequest:IRequest<KuyumcuSystemResult<string>>
    {
        public int ProductId { get; set; }
        public bool SalesStatus { get; set; }
    }
}
