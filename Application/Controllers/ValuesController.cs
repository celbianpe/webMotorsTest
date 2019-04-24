using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Contracts.Vehicles;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        readonly IVehicleRepository _repository;

        public ValuesController(IVehicleRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        

        [HttpGet]
        public async Task<IActionResult> Get()
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



        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
