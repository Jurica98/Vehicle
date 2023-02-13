using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class VehicleMakeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<VehicleModelEntity>? VehicleModelEntitys { get; set; }
    }
}
