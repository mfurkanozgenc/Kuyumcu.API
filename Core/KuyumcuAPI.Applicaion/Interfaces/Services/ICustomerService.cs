using KuyumcuAPI.Application.Features.Commands.CustomerCommands.AddCustomerCommand;
using KuyumcuAPI.Application.Features.Commands.CustomerCommands.DeleteCustomerCommand;
using KuyumcuAPI.Application.Features.Commands.CustomerCommands.UpdateCustomerCommand;
using KuyumcuAPI.Application.Features.Queries.CustomerQueries.GetAllCustomerQuery;
using KuyumcuAPI.Domain.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<KuyumcuSystemResult<string>> CreateCustomer(AddCustomerCommandRequest request);
        Task<KuyumcuSystemResult<string>> UpdateCustomer(UpdateCustomerCommandRequest request);
        Task<KuyumcuSystemResult<string>> DeleteCustomer(DeleteCustomerCommandRequest request);
        Task<KuyumcuSystemResult<IList<GetAllCustomerQueryResponse>>> GetAllCustomer(GetAllCustomerQueryRequest request);
    }
}
