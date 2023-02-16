using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Common;
using Project.Model;
using Project.Model.Common;
using Project.Service.Common;
using Project.WebAPI.RestModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _service;
        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleModelService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("VehicleModels")]
        public async Task<ActionResult<List<IVehicleModel>>> GetVehicleModelsAsync()
        {
            try
            {
                var vehicleModel = await _service.GetVehicleModels();
                var vehicleModelRest = _mapper.Map<List<VehicleModelRest>>(vehicleModel);
                if (vehicleModelRest == null)
                {
                    return NotFound();
                }
                return Ok(vehicleModelRest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("PagedVehicleModels")]
        public async Task<ActionResult<List<IVehicleModel>>> GetPagedVehicleModelsAsync([FromQuery] RequestParams requestParams)
        {
            try
            {
                var vehicleModel = await _service.GetPagedVehicleModels(requestParams);
                var vehicleModelRest = _mapper.Map<List<VehicleModelRest>>(vehicleModel);
                if (vehicleModelRest == null)
                {
                    return NotFound();
                }
                return Ok(vehicleModelRest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("VehicleModelsOrderBy")]
        public async Task<ActionResult<List<IVehicleModel>>> GetVehicleModelsOrderByNameAsync()
        {
            try
            {
                var vehicleModel = await _service.GetVehicleModelsOrderByName();
                var vehicleModelRest = _mapper.Map<List<VehicleModelRest>>(vehicleModel);
                return Ok(vehicleModelRest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("VehicleModelsFilterBy")]
        public async Task<ActionResult<List<IVehicleModel>>> GetVehicleModelsFilterByNameAsync(string name)
        {
            try
            {
                var vehicleModels = await _service.GetVehicleModelsFilerByName(name);
                var vehicleModelsRest = _mapper.Map<List<VehicleModelRest>>(vehicleModels);
                return Ok(vehicleModelsRest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}", Name = "GetVehicleModel")]
        public async Task<ActionResult<IVehicleMake>> GetVehicleModelAsync(int id)
        {
            try
            {
                var vehicleModel = await _service.GetVehicleModel(id);
                var vehicleModelRest = _mapper.Map<VehicleModelRest>(vehicleModel);
                if (vehicleModelRest == null)
                {
                    return NotFound();
                }
                return Ok(vehicleModelRest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

       

        [HttpPost]
        public async Task<IActionResult> CreateVehicleModelAsync([FromBody] CreateVehicleModelRest vehicleModel)
        {

            try
            {
                var _VehicleModel = _mapper.Map<VehicleModel>(vehicleModel);
                var newVehicleModel = await _service.CreateVehicleModel(_VehicleModel);
                return Ok(newVehicleModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVehicleModelAsync(int id, [FromBody] UpdateVehicleModelRest vehicleModel)
        {
            try
            {
                if (!ModelState.IsValid || id < 1)
                {
                    return BadRequest("Invalid UPDATE attempt");
                }
                var _VehicleModel= _mapper.Map<UpdateVehicleModel>(vehicleModel);
                return Ok(await _service.UpdateVehicleModel(id, _VehicleModel));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVehicleModelAsync(int id)
        {
            try
            {
                if (!ModelState.IsValid || id < 1)
                {
                    return BadRequest("Invalid DELETE attempt");
                }
                return Ok(await _service.DeleteVehicleModel(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
