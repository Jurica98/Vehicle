using Microsoft.EntityFrameworkCore;
using Project.Model;
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

        public DbSet<VehicleMake> VehicleMakes => Set<VehicleMake>();
        public DbSet<VehicleModel> VehicleModels => Set<VehicleModel>();
    }
}

