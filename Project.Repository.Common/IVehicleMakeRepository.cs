using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<List<IVehicleMake>> GetOrderByName();
        Task<List<IVehicleMake>> GetFilterByName(string search = null);
    }
}
