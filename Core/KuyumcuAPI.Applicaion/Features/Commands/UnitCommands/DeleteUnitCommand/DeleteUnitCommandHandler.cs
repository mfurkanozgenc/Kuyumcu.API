using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.UnitCommands.DeleteUnitCommand
{
    public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommandRequest, KuyumcuSystemResult<string>>
    {
        private readonly IUnitService unitService;

        public DeleteUnitCommandHandler(IUnitService unitService)
        {
            this.unitService = unitService;
        }
        public async Task<KuyumcuSystemResult<string>> Handle(DeleteUnitCommandRequest request, CancellationToken cancellationToken)
        {
            return await unitService.DeleteUnit(request);
        }
    }
}
