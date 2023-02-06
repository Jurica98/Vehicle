using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{

    public class VehicleMake : IVehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<VehicleModel>? VehicleModels { get; set; }
    }
}