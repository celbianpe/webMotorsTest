using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisingController : ControllerBase
    {
        readonly Repository.Contracts.Advertising.IAdvertisingRepository _repository;

        public AdvertisingController(Repository.Contracts.Advertising.IAdvertisingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvertising(Dtos.AdvertisingDto advertising)
        {
            try
            {
                var RepoParam = Mapper.Map<AdvertisingModel>(advertising);

                var UserResult = await _repository.Create(RepoParam);

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

        [HttpGet]
        public async Task<IActionResult> ListAdvertising()
        {
            try
            {
                
                var UserResult = await _repository.List();

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

        [HttpPatch]
        public async Task<IActionResult> UpdateAdvertising(Dtos.AdvertisingDto advertising)
        {
            try
            {
                var RepoParam = Mapper.Map<AdvertisingModel>(advertising);

                var UserResult = await _repository.UpdateItem(RepoParam);

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


        [HttpDelete]
        public async Task<IActionResult> RemoveAdvertising(int advertisingId)
        {
            try
            {

                var UserResult = await _repository.RemoveItem(advertisingId);

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



    }
}
