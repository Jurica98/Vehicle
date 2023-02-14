using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Model;
using Project.Model.Common;
using Project.Repository;
using Project.Repository.Common;
using Project.Service.Common;
using System.Diagnostics.Metrics;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService _service;
        
        public VehicleMakeController(IVehicleMakeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("VehicleMakes")]
        public async Task<ActionResult<List<IVehicleMake>>> GetVehicleMakesAsync()
        {
            return Ok(await _service.GetVehicleMakes());
        }

        [HttpGet("{id:int}", Name = "GetVehicleMake")]
        public async Task<ActionResult<IVehicleMake>> GetVehicleMakeAsync(int id)
        {
            return Ok(await _service.GetVehicleMake(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleMakeAsync([FromBody] CreateVehicleMake vehicleMake)
        {

            return Ok(await _service.CreateVehicleMake(vehicleMake));

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVehicleMakeAsync(int id, [FromBody] UpdateVehicleMake vehicleMake)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest("Invalid UPDATE attempt");
            }
            return Ok(await _service.UpdateVehicleMake(id, vehicleMake)); ;

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVehicleMakeAsync(int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest("Invalid DELETE attempt");
            }
            return Ok(await _service.DeleteVehicleMake(id)); ;

        }
    }

}
