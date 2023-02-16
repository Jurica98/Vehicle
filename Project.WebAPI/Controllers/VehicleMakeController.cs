using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Common;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository;
using Project.Repository.Common;
using Project.Service.Common;
using Project.WebAPI.RestModels;
using System.Diagnostics.Metrics;

namespace Project.WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService _service;
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMakeService service, IMapper mapper)
        {
            _service = service;
            _mapper= mapper;
        }

        [HttpGet]
        [Route("VehicleMakes")]
        public async Task<ActionResult<List<IVehicleMake>>> GetVehicleMakesAsync()
        {
            try
            {
                var vehicleMakes = await _service.GetVehicleMakes();
                var vehicleMakesRest = _mapper.Map<List<VehicleMakeRest>>(vehicleMakes);
                return Ok(vehicleMakesRest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("PagedVehicleMakes")]
        public async Task<ActionResult<List<IVehicleMake>>> GetPagedVehicleMakesAsync([FromQuery] RequestParams requestParams)
        {
            try
            {
                var vehicleMakes = await _service.GetPagedVehicleMakes(requestParams);
                var vehicleMakesRest = _mapper.Map<List<VehicleMakeRest>>(vehicleMakes);
                return Ok(vehicleMakesRest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("VehicleMakesOrderBy")]
        public async Task<ActionResult<List<IVehicleMake>>> GetVehicleMakesOrderByNameAsync()
        {
            try
            {
                var vehicleMakes = await _service.GetVehicleMakesOrderByName();
                var vehicleMakesRest = _mapper.Map<List<VehicleMakeRest>>(vehicleMakes);
                return Ok(vehicleMakesRest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("VehicleMakesFilterBy")]
        public async Task<ActionResult<List<IVehicleMake>>> GetVehicleMakesFilterByNameAsync(string name)
        {
            try
            {
                var vehicleMakes = await _service.GetVehicleMakesFilerByName(name);
                var vehicleMakesRest = _mapper.Map<List<VehicleMakeRest>>(vehicleMakes);
                return Ok(vehicleMakesRest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}", Name = "GetVehicleMake")]

        public async Task<ActionResult<IVehicleMake>> GetVehicleMakeAsync(int id)
        {
            try
            {
                var vehicleMake = await _service.GetVehicleMake(id);
                var vehicleMakesRest = _mapper.Map<VehicleMakeRest>(vehicleMake);
                if (vehicleMake == null)
                {
                    return NotFound();
                }
                return Ok(vehicleMakesRest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleMakeAsync([FromBody] CreateVehicleMakeRest vehicleMake)
        {
            try
            {
                var _VehicleMake = _mapper.Map<VehicleMake>(vehicleMake);
                var newVehicleMake = await _service.CreateVehicleMake(_VehicleMake);
                return Ok(newVehicleMake);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVehicleMakeAsync(int id, [FromBody] UpdateVehicleMakeRest vehicleMake)
        {
            try
            {
                if (!ModelState.IsValid || id < 1)
                {
                    return BadRequest("Invalid UPDATE attempt");
                }
                var _VehicleMake = _mapper.Map<UpdateVehicleMake>(vehicleMake);
                var updatedVehicleMake = await _service.UpdateVehicleMake(id, _VehicleMake);
                if (updatedVehicleMake == false)
                {
                    return NotFound();
                }
                return Ok(updatedVehicleMake);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVehicleMakeAsync(int id)
        {
            try
            {
                if (!ModelState.IsValid || id < 1)
                {
                    return BadRequest("Invalid DELETE attempt");
                }
                var deleted = await _service.DeleteVehicleMake(id);
                if (deleted == false)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }

}
