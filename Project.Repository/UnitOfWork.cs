using Project.DAL;
using Project.DAL.Entities;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IGenericRepository<VehicleMakeEntity> _VehicleMakeEntitys;
        private IGenericRepository<VehicleModelEntity> _VehicleModelEntitys;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IGenericRepository<VehicleMakeEntity> VehicleMakeEntitys => _VehicleMakeEntitys ??= new GenericRepository<VehicleMakeEntity>(_context);

        public IGenericRepository<VehicleModelEntity> VehicleModelEntitys => _VehicleModelEntitys ??= new GenericRepository<VehicleModelEntity>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
