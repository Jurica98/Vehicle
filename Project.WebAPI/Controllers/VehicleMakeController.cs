using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        /*
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleMakeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("VehicleMakes")]
        public async Task<IActionResult> GetMakes()
        {
            var Makes = await _unitOfWork.VehicleMakeEntitys.GetAll();
            var resault = _mapper.Map<List<VehicleMake>>(Makes);
            return Ok(resault);
        }*/
        
        private readonly IVehicleMakeService _service;
        
        public VehicleMakeController(IVehicleMakeService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("VehicleMakes")]
        public async Task<ActionResult<List<IVehicleMake>>> GetVehicleMakeAsync()
        {
            return Ok(await _service.GetVehicleMakes());
        }
        
    }

}
