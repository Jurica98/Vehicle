using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Project.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VehicleMakeRepository(DataContext context, IMapper mapper)
        {
            _context= context;
            _mapper = mapper;
        }
        public async Task<List<IVehicleMake>> GetOrderByName()
        {
            var entities = await _context.VehicleMakes.OrderBy(vm => vm.Name).ToListAsync();
            return new List<IVehicleMake>(_mapper.Map<List<VehicleMake>>(entities).ToList());
        }
        public async Task<List<IVehicleMake>> GetFilterByName(string search = null)
        {
            var query = _context.VehicleMakes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(vm => vm.Name.StartsWith(search));
            }

            var entities = await query.ToListAsync();
            return new List<IVehicleMake>(_mapper.Map<List<VehicleMake>>(entities));
        }


    }
}
