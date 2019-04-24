using Kernel.Core;
using Kernel.Core.Utils;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Repository.Contracts.Vehicles;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements
{
    public class VehiclesRepository : IVehicleRepository
    {
        readonly IHttpClientFactory _httpClientFactory;
        readonly IConfiguration _config;
        readonly string _clientName;
        readonly IDistributedCache _cache;

        public VehiclesRepository(IHttpClientFactory ClientFactory, IConfiguration config, IDistributedCache cache)
        {
            _config = config;
            _httpClientFactory = ClientFactory;
            _clientName = _config.GetValue<string>(EnviromentConstants.WEB_CLIENT.GetName());
            _cache = cache;
        }

        public async Task<Results.GetVehicleMakesResult> ListVehicleMakes()
        {

            var result = new Results.GetVehicleMakesResult();
            try
            {
                var redisInternalKey = $"{nameof(VehiclesRepository)}-{nameof(Results.GetVehicleMakesResult)}";
                //check value on redis cache
                string jsonValue = _cache.GetString(redisInternalKey);


                if (!string.IsNullOrEmpty(jsonValue))
                {
                    result = JsonConvert.DeserializeObject<Results.GetVehicleMakesResult>(jsonValue);


                    return result;
                }

                var root = _config.GetValue<string>(EnviromentConstants.MAKE_ROOT.GetName());

                using (var httpClient = _httpClientFactory.CreateClient(_clientName))
                {
                    var makes = new List<VehicleMakeModel>();

                    var request = new HttpRequestMessage(HttpMethod.Get, root);

                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var vehiclesResponse = await response.Content.ReadAsAsync<IEnumerable<VehicleMakeModel>>();

                        result.VehicleMakes = vehiclesResponse;

                        _cache.SetString(redisInternalKey, JsonConvert.SerializeObject(result), 
                            new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(2)));
                    }

                }
            }
            catch (Exception ex)
            {
                result.AddSystemError(ex);
            }

            return result;
        }

        public async Task<Results.GetVehicleModelsResult> ListVehicleModels(int makeId)
        {
            var result = new Results.GetVehicleModelsResult();
            try
            {
                var redisInternalKey = $"{nameof(VehiclesRepository)}-{nameof(Results.GetVehicleModelsResult)}";
                //check value on redis cache
                string jsonValue = _cache.GetString(redisInternalKey);


                if (!string.IsNullOrEmpty(jsonValue))
                {
                    result = JsonConvert.DeserializeObject<Results.GetVehicleModelsResult>(jsonValue);

                    return result;
                }


                var root = _config.GetValue<string>(EnviromentConstants.MODEL_ROOT.GetName());



                using (var httpClient = _httpClientFactory.CreateClient(_clientName))
                {
                    var makes = new List<VehicleMakeModel>();

                    var request = new HttpRequestMessage(HttpMethod.Get, root);

                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var modelsResponse = await response.Content.ReadAsAsync<IEnumerable<VehicleModelModel>>();

                        result.VehicleModels = modelsResponse;

                        _cache.SetString(redisInternalKey, JsonConvert.SerializeObject(result),
                        new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(2)));
                    }

                }
            }
            catch (Exception ex)
            {
                result.AddSystemError(ex);
            }

            return result;
        }

        public Task<IEnumerable<VehicleModel>> ListVehicles(int page)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleVersionModel>> ListVehicleVersions(int modelId)
        {
            throw new NotImplementedException();
        }
    }
}
