using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class DIModule : Profile
    {
        public DIModule()
        {
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<VehicleMake, IVehicleMake>().ReverseMap();

            CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModel>().ReverseMap();


        }
    }
}
