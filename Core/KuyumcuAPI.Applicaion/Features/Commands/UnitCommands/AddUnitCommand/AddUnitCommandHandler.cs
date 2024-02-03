using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.UnitCommands.AddUnitCommand
{
    public class AddUnitCommandHandler : IRequestHandler<AddUnitCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IUnitService unitService;

        public AddUnitCommandHandler(IUnitService unitService)
        {
            this.unitService = unitService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(AddUnitCommandRequest request, CancellationToken cancellationToken)
        {
            return await unitService.CreateUnit(request);
        }
    }
}
