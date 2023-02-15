using AutoMapper;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Entities;
using Project.Common;


namespace Project.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<IVehicleModel>> GetVehicleModels()
        {
            var VehicleModelEntitys = await _unitOfWork.VehicleModelEntitys.GetAll();
            return new List<IVehicleModel>(_mapper.Map<List<VehicleModel>>(VehicleModelEntitys).ToList());
        }

        public async Task<List<IVehicleModel>> GetPagedVehicleModels(RequestParams requestParams)
        {
            var VehicleModelEntitys = await _unitOfWork.VehicleModelEntitys.GetPaged(requestParams);
            return new List<IVehicleModel>(_mapper.Map<List<VehicleModel>>(VehicleModelEntitys).ToList());
        }

        public async Task<IVehicleModel> GetVehicleModel(int id)
        {
            var VehicleModelEntity = await _unitOfWork.VehicleModelEntitys.Get(q => q.Id == id);
            return (IVehicleModel)_mapper.Map<VehicleModel>(VehicleModelEntity);
        }


        public async Task<bool> CreateVehicleModel(VehicleModel vehicleModel)
        {
            var _VehicleModel = _mapper.Map<VehicleModelEntity>(vehicleModel);
            await _unitOfWork.VehicleModelEntitys.Insert(_VehicleModel);
            await _unitOfWork.Save();

            return true;
        }

        public async Task<bool> UpdateVehicleModel(int id, UpdateVehicleModel vehicleModel)
        {
            var _VehicleModel = await _unitOfWork.VehicleModelEntitys.Get(q => q.Id == id);
            if (_VehicleModel == null)
            {
                return false;
            }

            _mapper.Map(vehicleModel, _VehicleModel);
            _unitOfWork.VehicleModelEntitys.Update(_VehicleModel);
            await _unitOfWork.Save();

            return true;
        }

        public async Task<bool> DeleteVehicleModel(int id)
        {
            var _VehicleModel = await _unitOfWork.VehicleModelEntitys.Get(q => q.Id == id);
            if (_VehicleModel == null)
            {
                return false;
            }
            await _unitOfWork.VehicleModelEntitys.Delete(id);
            await _unitOfWork.Save();

            return true;
        }

    }
}
