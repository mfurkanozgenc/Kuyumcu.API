using KuyumcuAPI.Application.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Helpers
{
    public class AuthHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public LookupValue GetUserObj()
        {
            var record = new LookupValue();
            var claims = ((ClaimsIdentity)_httpContextAccessor?.HttpContext?.User?.Identity)?.Claims;

            if (claims.Any())
            {
                record.Id = int.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                record.Value = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            }
            return record;
        }
    }
}
