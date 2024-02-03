using KuyumcuAPI.Application.Interfaces.AutoMapper;
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

namespace KuyumcuAPI.Application.Features.Commands.CategoryCommands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly ICategoryService categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            return await categoryService.UpdateCategory(request);
        }
    }
}
