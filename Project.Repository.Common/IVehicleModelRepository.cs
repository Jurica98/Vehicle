using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task<List<IVehicleModel>> GetOrderByName();
        Task<List<IVehicleModel>> GetFilterByName(string search = null);
    }
}
