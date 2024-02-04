using KuyumcuAPI.Application.Features.Commands.SalesCommand.AddSalesCommand;
using KuyumcuAPI.Domain.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Interfaces.Services
{
    public interface ISaleService
    {
        Task<KuyumcuSystemResult<string>> CreateSale(AddSalesCommandRequest request);
    }
}
