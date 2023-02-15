using Project.Model;

namespace Project.WebAPI.RestModels
{
    public class VehicleModelRest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int VehicleMakeEntityId { get; set; }
        
    }
}
