using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CategoryCommands.DeleteCategoryCommand
{
    public record DeleteCategoryCommandRequest(int categoryId):IRequest<KuyumcuSystemResult<string>>
    {
    }
}
