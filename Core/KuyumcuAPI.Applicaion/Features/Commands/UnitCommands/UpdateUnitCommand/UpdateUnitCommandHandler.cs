using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.UnitCommands.UpdateUnitCommand
{
    public class UpdateUnitCommandHandler : IRequestHandler<UpdateUnitCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IUnitService unitService;

        public UpdateUnitCommandHandler(IUnitService unitService)
        {
            this.unitService = unitService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(UpdateUnitCommandRequest request, CancellationToken cancellationToken)
        {
            return await unitService.UpdateUnit(request);
        }
    }
}
