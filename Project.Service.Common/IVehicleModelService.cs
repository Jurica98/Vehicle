using Project.Model.Common;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Common;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
        Task<List<IVehicleModel>> GetVehicleModels();
        Task<List<IVehicleModel>> GetPagedVehicleModels(RequestParams requestParams);
        Task<IVehicleModel> GetVehicleModel(int id);
        Task<bool> CreateVehicleModel(VehicleModel vehicleModel);
        Task<bool> UpdateVehicleModel(int id, UpdateVehicleModel vehicleModel);
        Task<bool> DeleteVehicleModel(int id);
    }
}
