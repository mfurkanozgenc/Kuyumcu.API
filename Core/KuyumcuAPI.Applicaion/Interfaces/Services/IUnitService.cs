using KuyumcuAPI.Application.Features.Commands.UnitCommands.AddUnitCommand;
using KuyumcuAPI.Application.Features.Commands.UnitCommands.DeleteUnitCommand;
using KuyumcuAPI.Application.Features.Commands.UnitCommands.UpdateUnitCommand;
using KuyumcuAPI.Domain.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Interfaces.Services
{
    public interface IUnitService
    {
        Task<KuyumcuSystemResult<string>> CreateUnit(AddUnitCommandRequest request);
        Task<KuyumcuSystemResult<string>> UpdateUnit(UpdateUnitCommandRequest request);
        Task<KuyumcuSystemResult<string>> DeleteUnit(DeleteUnitCommandRequest request);
    }
}
