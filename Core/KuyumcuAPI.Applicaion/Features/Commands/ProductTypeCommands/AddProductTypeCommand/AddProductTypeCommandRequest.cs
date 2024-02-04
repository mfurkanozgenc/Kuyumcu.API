using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.AddProductTypeCommand
{
    public class AddProductTypeCommandRequest:IRequest<KuyumcuSystemResult<string>>
    {
        public string Name { get; set; }
    }
}
