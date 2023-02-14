using Microsoft.AspNetCore.Mvc;
using Project.Model;
using Project.Model.Common;
using Project.Service.Common;


namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _service;

        public VehicleModelController(IVehicleModelService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("VehicleModels")]
        public async Task<ActionResult<List<IVehicleModel>>> GetVehicleModelsAsync()
        {
            return Ok(await _service.GetVehicleModels());
        }

        [HttpGet("{id:int}", Name = "GetVehicleModel")]
        public async Task<ActionResult<IVehicleMake>> GetVehicleModelAsync(int id)
        {
            return Ok(await _service.GetVehicleModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleModelAsync([FromBody] CreateVehicleModel vehicleModel)
        {

            return Ok(await _service.CreateVehicleModel(vehicleModel));

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVehicleModelAsync(int id, [FromBody] UpdateVehicleModel vehicleModel)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest("Invalid UPDATE attempt");
            }
            return Ok(await _service.UpdateVehicleModel(id, vehicleModel)); ;

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVehicleModelAsync(int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest("Invalid DELETE attempt");
            }
            return Ok(await _service.DeleteVehicleModel(id)); ;

        }
    }
}
