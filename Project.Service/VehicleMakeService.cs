using AutoMapper;
using Project.Common;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVehicleMakeRepository _VehicleMakeRepository;

        public VehicleMakeService(IUnitOfWork unitOfWork, IMapper mapper, IVehicleMakeRepository VehicleMakeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _VehicleMakeRepository= VehicleMakeRepository;
        }

        
        public async Task<IVehicleMake> GetVehicleMake(int id)
        {
            var VehicleMakeEntity = await _unitOfWork.VehicleMakeEntitys.Get(q => q.Id == id);
            return (IVehicleMake)_mapper.Map<VehicleMake>(VehicleMakeEntity);
        }

        public async Task<List<IVehicleMake>> GetVehicleMakes()
        {
            var VehicleMakeEntitys = await _unitOfWork.VehicleMakeEntitys.GetAll();
            return new List<IVehicleMake>(_mapper.Map<List<VehicleMake>>(VehicleMakeEntitys).ToList());
        }

        public async Task<List<IVehicleMake>> GetPagedVehicleMakes(RequestParams requestParams)
        {
            var VehicleMakeEntitys = await _unitOfWork.VehicleMakeEntitys.GetPaged(requestParams);
            return new List<IVehicleMake>(_mapper.Map<List<VehicleMake>>(VehicleMakeEntitys).ToList());
        }
        public async Task<List<IVehicleMake>> GetVehicleMakesOrderByName()
        {
            var VehicleMakeEntitys = await _VehicleMakeRepository.GetOrderByName();
            return new List<IVehicleMake>(VehicleMakeEntitys.ToList());
        }

        public async Task<List<IVehicleMake>> GetVehicleMakesFilerByName(string name)
        {
            var VehicleMakeEntitys = await _VehicleMakeRepository.GetFilterByName(name);
            return new List<IVehicleMake>(VehicleMakeEntitys.ToList());
        }

        public async Task<bool> CreateVehicleMake(VehicleMake vehicleMake)
        {
            var _VehicleMake = _mapper.Map<VehicleMakeEntity>(vehicleMake);
            await _unitOfWork.VehicleMakeEntitys.Insert(_VehicleMake);
            await _unitOfWork.Save();

            return true;
        }

        public async Task<bool> UpdateVehicleMake(int id, UpdateVehicleMake vehicleMake)
        {
            var _VehicleMake = await _unitOfWork.VehicleMakeEntitys.Get(q => q.Id == id);
            if (_VehicleMake == null)
            {
                return false;
            }

            _mapper.Map(vehicleMake, _VehicleMake);
            _unitOfWork.VehicleMakeEntitys.Update(_VehicleMake);
            await _unitOfWork.Save();

            return true;
        }

        public async Task<bool> DeleteVehicleMake(int id)
        {
            var _VehicleMake = await _unitOfWork.VehicleMakeEntitys.Get(q => q.Id == id);
            if (_VehicleMake == null)
            {
                return false;
            }
            await _unitOfWork.VehicleMakeEntitys.Delete(id);
            await _unitOfWork.Save();

            return true;
        }
    }
}
