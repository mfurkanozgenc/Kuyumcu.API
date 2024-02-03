using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.CategoryCommands.AddCategoryCommand
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly ICategoryService categoryService;

        public AddCategoryCommandHandler(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            return await categoryService.CreateCategory(request);
        }
    }
}
