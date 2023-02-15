using AutoMapper;
using Project.DAL.Entities;
using Project.Model.Common;
using Project.Model;

namespace Project.WebAPI.RestModels
{
    public class DIModule : Profile
    {
        public DIModule()
        {
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<UpdateVehicleMake, VehicleMakeEntity>().ReverseMap();
            CreateMap<VehicleMakeRest, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeRest, IVehicleMake>().ReverseMap();
            CreateMap<CreateVehicleMakeRest, VehicleMake>().ReverseMap();
            CreateMap<UpdateVehicleMakeRest, UpdateVehicleMake>().ReverseMap();

            CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            CreateMap<UpdateVehicleModel, VehicleModelEntity>().ReverseMap();
            CreateMap<VehicleModelRest, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelRest, IVehicleModel>().ReverseMap();
            CreateMap<CreateVehicleModelRest, VehicleModel>().ReverseMap();
            CreateMap<UpdateVehicleModelRest, UpdateVehicleModel>().ReverseMap();

        }
    }
}
