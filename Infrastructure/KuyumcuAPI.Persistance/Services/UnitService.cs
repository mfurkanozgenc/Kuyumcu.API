using KuyumcuAPI.Application.Features.Commands.UnitCommands.AddUnitCommand;
using KuyumcuAPI.Application.Features.Commands.UnitCommands.DeleteUnitCommand;
using KuyumcuAPI.Application.Features.Commands.UnitCommands.UpdateUnitCommand;
using KuyumcuAPI.Application.Interfaces.AutoMapper;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Domain.ApiResult;
using KuyumcuAPI.Domain.Entities;
using KuyumcuAPI.Domain.Enumarations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private ReturnResult returnResult;

        public UnitService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            returnResult = new ReturnResult();
        }
        public async Task<KuyumcuSystemResult<string>> CreateUnit(AddUnitCommandRequest request)
        {
            if(request.IsGram && request.IsCount)
            {
                return returnResult.ErrorResponse("Gram ve Adet birimi aynı anda seçilemez");
            }
            if(!request.IsGram && !request.IsCount)
            {
                return returnResult.ErrorResponse("Birim seçimi zorunlu");
            }
            if(string.IsNullOrEmpty(request.Name))
            {
                return returnResult.ErrorResponse("Birim adı boş olamaz");
            }
            var unit = mapper.Map<Domain.Entities.Unit, AddUnitCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Domain.Entities.Unit>().AddAsync(unit);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse("Birim ekleme başarılı");
        }

        public async Task<KuyumcuSystemResult<string>> DeleteUnit(DeleteUnitCommandRequest request)
        {
            var oldUnit = await unitOfWork.GetReadRepository<Domain.Entities.Unit>().GetAsync(u => u.Id == request.unitId);
            if (oldUnit == null)
            {
                return returnResult.ErrorResponse("Birim bulunamadı");
            }
            oldUnit.IsDeleted = true;
            oldUnit.DeletedDate = DateTime.Now;
            await unitOfWork.GetWriteRepository<Domain.Entities.Unit>().UpdatAsync(oldUnit);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse("Birim silme başarılı");
        }

        public async Task<KuyumcuSystemResult<string>> UpdateUnit(UpdateUnitCommandRequest request)
        {
            var oldUnit = await unitOfWork.GetReadRepository<Domain.Entities.Unit>().GetAsync(u => u.Id == request.Id);
            if(oldUnit == null) 
            {
                return returnResult.ErrorResponse("Birim bulunamadı");
            }
            if (request.IsGram && request.IsCount)
            {
                return returnResult.ErrorResponse("Gram ve Adet birimi aynı anda seçilemez");
            }
            if (!request.IsGram && !request.IsCount)
            {
                return returnResult.ErrorResponse("Birim seçimi zorunlu");
            }
            if (string.IsNullOrEmpty(request.Name))
            {
                return returnResult.ErrorResponse("Birim adı boş olamaz");
            }
            var unit = mapper.Map<Domain.Entities.Unit, UpdateUnitCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Domain.Entities.Unit>().UpdatAsync(unit);
            await unitOfWork.SaveAsync();
            return returnResult.SuccessResponse("Birim güncelleme başarılı");
        }
    }
}
