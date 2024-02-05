using KuyumcuAPI.Application.Features.Commands.AuthCommand.LoginAuthCommand;
using KuyumcuAPI.Application.Interfaces.AutoMapper;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using KuyumcuAPI.Domain.Enumarations;
using KuyumcuAPI.Infrastructure.Cryptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AuthService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<KuyumcuSystemResult<LoginAuthCommandResponse>> Login(LoginAuthCommandRequest request)
        {
            var user=await unitOfWork.GetReadRepository<User>().GetAsync(u=>u.UserName == request.UserName && u.Password==request.Password && !u.IsDeleted);
            if(user == null)
            {
                return new()
                {
                    ErrorCode = Result.Error,
                    ErrorMessage = "Kullanıcı adı ya da şifre hatalı",
                    Value = null
                };
            }
            if (string.IsNullOrEmpty(user.ApiKey))
            {
                var apiKey = ApiKey.CreateApiKey();
                user.ApiKey = apiKey;
                await unitOfWork.GetWriteRepository<User>().UpdatAsync(user);
                await unitOfWork.SaveAsync();
            }
            var mapUser = mapper.Map<LoginAuthCommandResponse, User>(user);
            return new()
            {
                ErrorCode = Result.Successful,
                ErrorMessage = "Giriş başarılı",
                Value = mapUser
            };
        }
    }
}
