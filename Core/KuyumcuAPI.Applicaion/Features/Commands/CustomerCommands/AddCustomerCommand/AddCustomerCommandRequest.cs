using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CustomerCommands.AddCustomerCommand
{
    public class AddCustomerCommandRequest:IRequest<KuyumcuSystemResult<string>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdentificationNumber { get; set; }
        public string?   PhoneNumber { get; set; }
        public string? Address { get; set; }
        public Gender?  Gender{ get; set; }
        public decimal? Balance { get; set; }
    }
}
