using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.ProductTypeCommands.DeleteProductTypeCommand
{
    public record DeleteProductTypeCommandRequest(int productTypeId):IRequest<KuyumcuSystemResult<string>>
    {
    }
}
