﻿using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<VehicleMakeEntity> VehicleMakeEntitys { get; }
        IGenericRepository<VehicleModelEntity> VehicleModelEntitys { get; }
        Task Save();

    }
}