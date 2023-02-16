using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VehicleModelRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<IVehicleModel>> GetOrderByName()
        {
            var entities = await _context.VehicleModels.OrderBy(vm => vm.Name).ToListAsync();
            return new List<IVehicleModel>(_mapper.Map<List<VehicleModel>>(entities).ToList());
        }

        public async Task<List<IVehicleModel>> GetFilterByName(string search = null)
        {
            var query = _context.VehicleModels.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(vm => vm.Name.StartsWith(search));
            }

            var entities = await query.ToListAsync();
            return new List<IVehicleModel>(_mapper.Map<List<VehicleModel>>(entities));
        }
    }
}
