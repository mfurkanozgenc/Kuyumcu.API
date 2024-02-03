using KuyumcuAPI.Domain.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.ApiResult
{
    public class KuyumcuSystemResult<T>
    {
        public required T Value { get; set; }

        public Result ErrorCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
