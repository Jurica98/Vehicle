using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<VehicleMakeEntity> VehicleMakes => Set<VehicleMakeEntity>();
        public DbSet<VehicleModelEntity> VehicleModels => Set<VehicleModelEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VehicleMakeEntity>().HasData
            (
                new VehicleMakeEntity
                {
                    Id = 1,
                    Name = "Volkswagen",
                    Abrv = "VW"
                },
                new VehicleMakeEntity
                {
                    Id = 2,
                    Name = "Audi",
                    Abrv = "audi"
                },
                new VehicleMakeEntity
                {
                    Id = 3,
                    Name = "Bavarian Motor Works",
                    Abrv = "BMW"
                }
             );
            builder.Entity<VehicleModelEntity>().HasData
            (
                new VehicleModelEntity
                {
                    Id = 1,
                    Name = "Golf 7",
                    Abrv = "VW",
                    VehicleMakeEntityId = 1
                },
                new VehicleModelEntity
                {
                    Id = 2,
                    Name = "A4",
                    Abrv = "audi",
                    VehicleMakeEntityId = 2
                },
                new VehicleModelEntity
                {
                    Id = 3,
                    Name = "M4",
                    Abrv = "BMW",
                    VehicleMakeEntityId = 3
                }
             );
        }

    }
}

