﻿using Project.Model;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<List<IVehicleMake>> GetVehicleMakes();
        Task<IVehicleMake> GetVehicleMake(int id);
        Task<bool> CreateVehicleMake(CreateVehicleMake vehicleMake);
        Task<bool> UpdateVehicleMake(int id, UpdateVehicleMake vehicleMake);
        Task<bool> DeleteVehicleMake(int id);
    }
}
