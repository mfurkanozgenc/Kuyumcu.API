using KuyumcuAPI.Application.Features.Commands.AuthCommand.LoginAuthCommand;
using KuyumcuAPI.Application.Interfaces.AutoMapper;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using KuyumcuAPI.Domain.Enumarations;
using KuyumcuAPI.Infrastructure.Cryptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        public async Task<KuyumcuSystemResult<LoginAuthCommandResponse>> Login(LoginAuthCommandRequest request)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(u => u.UserName == request.UserName && u.Password == request.Password && !u.IsDeleted);
            if (user == null)
            {
                return new()
                {
                    ErrorCode = Result.Error,
                    ErrorMessage = "Kullanıcı adı ya da şifre hatalı",
                    Value = null
                };
            }
            user.ApiKey = GenerateJwtToken(user);
            var mapUser = mapper.Map<LoginAuthCommandResponse, User>(user);
            return new()
            {
                ErrorCode = Result.Successful,
                ErrorMessage = "Giriş başarılı",
                Value = mapUser
            };
        }
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName)
                }),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
