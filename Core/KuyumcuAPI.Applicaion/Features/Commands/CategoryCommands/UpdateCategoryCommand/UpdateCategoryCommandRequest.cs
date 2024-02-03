using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CategoryCommands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandRequest:IRequest<KuyumcuSystemResult<string>>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
