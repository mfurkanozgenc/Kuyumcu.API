using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CategoryCommands.AddCategoryCommand
{
    public class AddCategoryCommandRequest:IRequest<KuyumcuSystemResult<string>>
    {
        public required string Name { get; set; }
    }
}
