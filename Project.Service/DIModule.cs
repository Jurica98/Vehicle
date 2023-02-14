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
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<CreateVehicleMake, VehicleMakeEntity>().ReverseMap();
            CreateMap<UpdateVehicleMake, VehicleMakeEntity>().ReverseMap();

            CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            CreateMap<CreateVehicleModel, VehicleModelEntity>().ReverseMap();
            CreateMap<UpdateVehicleModel, VehicleModelEntity>().ReverseMap();




        }
    }
}
