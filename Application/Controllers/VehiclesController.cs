using Microsoft.AspNetCore.Mvc;
using Repository.Contracts.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        readonly IVehicleRepository _repository;

        public VehiclesController(IVehicleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var UserResult = await _repository.ListVehicles();

                if (UserResult.Success)
                {
                    return Ok(UserResult);
                }

                return NotFound(UserResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("makes")]
        public async Task<IActionResult> ListMakes()
        {
            try
            {

                var UserResult = await _repository.ListVehicleMakes();

                if (UserResult.Success)
                {

                    return Ok(UserResult);
                }

                UserResult = null;
                return NotFound(UserResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("models")]
        public async Task<IActionResult> ListModel(int makeId)
        {
            try
            {

                var UserResult = await _repository.ListVehicleModels(makeId);

                if (UserResult.Success)
                {

                    return Ok(UserResult);
                }

                UserResult = null;
                return NotFound(UserResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("versions")]
        public async Task<IActionResult> ListVersions(int modelId)
        {
            try
            {

                var UserResult = await _repository.ListVehicleVersions(modelId);

                if (UserResult.Success)
                {

                    return Ok(UserResult);
                }

                UserResult = null;
                return NotFound(UserResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}