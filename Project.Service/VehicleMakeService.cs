using AutoMapper;
using Project.Model;
using Project.Model.Common;
using Project.Repository;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleMakeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<IVehicleMake>> GetVehicleMakes()
        {
            
            var VehicleMakeEntitys = await _unitOfWork.VehicleMakeEntitys.GetAll();
            return new List<IVehicleMake>(_mapper.Map<List<VehicleMake>>(VehicleMakeEntitys).ToList());
        }
    }
}
