using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Commands.UnitCommands.AddUnitCommand
{
    public class AddUnitCommandRequest:IRequest<KuyumcuSystemResult<string>>
    {
        public string Name { get; set; }
        public bool IsGram { get; set; }
        public bool IsCount { get; set; }
    }
}
