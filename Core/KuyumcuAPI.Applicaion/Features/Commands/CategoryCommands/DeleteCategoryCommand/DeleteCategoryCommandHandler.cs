using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CategoryCommands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly ICategoryService categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            return await categoryService.DeleteCategory(request);
        }
    }
}
