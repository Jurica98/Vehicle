using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
    public interface IVehicleMake
    {
        int Id { get; set; }
        string Abrv { get; set; }
        string Name { get; set; }
        



    }
}
