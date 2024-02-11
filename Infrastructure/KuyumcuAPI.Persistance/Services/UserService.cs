using KuyumcuAPI.Application.Features.Commands.UserCommands.AddUserCommand;
using KuyumcuAPI.Application.Features.Commands.UserCommands.DeleteUserCommand;
using KuyumcuAPI.Application.Features.Commands.UserCommands.UpdateUserCommand;
using KuyumcuAPI.Application.Interfaces.AutoMapper;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using KuyumcuAPI.Infrastructure.Cryptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ReturnResult returnResult;

        public UserService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            returnResult=new ReturnResult();
        }
        public async Task<KuyumcuSystemResult<string>> CreateUser(AddUserCommandRequest request)
        {
            var apiKey = ApiKey.CreateApiKey();
            var control=await unitOfWork.GetReadRepository<User>().GetAsync(u=>u.IdentificationNumber==request.IdentificationNumber || u.UserName==request.UserName);
            if (control != null)
            {
                return returnResult.ErrorResponse("Kullanıcı daha önce kayıt edilmiştir");
            }
            if(string.IsNullOrEmpty(request.FirstName))
            {
                return returnResult.ErrorResponse("Ad boş olamaz");
            }
            if (string.IsNullOrEmpty(request.LastName))
            {
                return returnResult.ErrorResponse("Soyad boş olamaz");
            }
            if (string.IsNullOrEmpty(request.UserName))
            {
                return returnResult.ErrorResponse("Kullanıcı adı boş olamaz");
            }
            if (string.IsNullOrEmpty(request.Password))
            {
                return returnResult.ErrorResponse("Şifre boş olamaz");
            }
            var map = mapper.Map<User, AddUserCommandRequest>(request);
            map.ApiKey= apiKey;
            await unitOfWork.GetWriteRepository<User>().AddAsync(map);
            await unitOfWork.SaveAsync();
            return returnResult.ErrorResponse(map.Id.ToString());
        }

        public async Task<KuyumcuSystemResult<string>> DeleteUser(DeleteUserCommandRequest request)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(u => u.Id == request.userId);
            if (user == null)
            {
                return returnResult.ErrorResponse("Kullanıcı bulunamadı");
            }
            user.IsDeleted = true;
            user.DeletedDate = DateTime.Now;
            await unitOfWork.GetWriteRepository<User>().UpdatAsync(user);
            await unitOfWork.SaveAsync();
            return returnResult.ErrorResponse("Kullanıcı silindi");
        }

        public async Task<KuyumcuSystemResult<string>> UpdateUser(UpdateUserCommandRequest request)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(u => u.Id == request.Id);
            if (user == null)
            {
                return returnResult.ErrorResponse("Kullanıcı bulunamadı");
            }
            var control = await unitOfWork.GetReadRepository<User>().GetAsync(u => (u.IdentificationNumber == request.IdentificationNumber || u.UserName == request.UserName) && u.Id!=request.Id);
            if (control != null)
            {
                return returnResult.ErrorResponse("Kullanıcı daha önce kayıt edilmiştir");
            }
            if (string.IsNullOrEmpty(request.FirstName))
            {
                return returnResult.ErrorResponse("Ad boş olamaz");
            }
            if (string.IsNullOrEmpty(request.LastName))
            {
                return returnResult.ErrorResponse("Soyad boş olamaz");
            }
            if (string.IsNullOrEmpty(request.UserName))
            {
                return returnResult.ErrorResponse("Kullanıcı adı boş olamaz");
            }
            if (string.IsNullOrEmpty(request.Password))
            {
                return returnResult.ErrorResponse("Şifre boş olamaz");
            }
            var map = mapper.Map<User, UpdateUserCommandRequest>(request);
            await unitOfWork.GetWriteRepository<User>().UpdatAsync(map);
            await unitOfWork.SaveAsync();
            return returnResult.ErrorResponse(user.Id.ToString());
        }
    }
}
