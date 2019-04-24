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
        TimeSpan CacheTimeOut = TimeSpan.FromHours(4);

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
                    var request = new HttpRequestMessage(HttpMethod.Get, root);

                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var vehiclesResponse = await response.Content.ReadAsAsync<IEnumerable<VehicleMakeModel>>();

                        result.VehicleMakes = vehiclesResponse;

                        _cache.SetString(redisInternalKey, JsonConvert.SerializeObject(result),
                            new DistributedCacheEntryOptions().SetAbsoluteExpiration(CacheTimeOut));
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

                var param = $"?MakeID={makeId}";

                using (var httpClient = _httpClientFactory.CreateClient(_clientName))
                {
                    
                    var request = new HttpRequestMessage(HttpMethod.Get, root + param);

                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var modelsResponse = await response.Content.ReadAsAsync<IEnumerable<VehicleModelModel>>();

                        result.VehicleModels = modelsResponse;

                        _cache.SetString(redisInternalKey, JsonConvert.SerializeObject(result),
                        new DistributedCacheEntryOptions().SetAbsoluteExpiration(CacheTimeOut));
                    }

                }
            }
            catch (Exception ex)
            {
                result.AddSystemError(ex);
            }

            return result;
        }

        public async Task<Results.GetVehiclesResult> ListVehicles()
        {
            var result = new Results.GetVehiclesResult();
            try
            {
                var redisInternalKey = $"{nameof(VehiclesRepository)}-{nameof(Results.GetVehiclesResult)}";
                //check value on redis cache
                string jsonValue = _cache.GetString(redisInternalKey);


                if (!string.IsNullOrEmpty(jsonValue))
                {
                    result = JsonConvert.DeserializeObject<Results.GetVehiclesResult>(jsonValue);

                    return result;
                }
                
                var root = _config.GetValue<string>(EnviromentConstants.VEHICLE_ROOT.GetName());

                using (var httpClient = _httpClientFactory.CreateClient(_clientName))
                {
                    var vehicles = new List<VehicleModel>();
                    var page = 1;
                    var stopWhile = true;
                    do
                    {
                        var param = $"?Page={page}";

                        var request = new HttpRequestMessage(HttpMethod.Get, root + param);

                        var response = await httpClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            var modelsResponse = await response.Content.ReadAsAsync<IEnumerable<VehicleModel>>();

                            if (modelsResponse.Any())
                                vehicles.AddRange(modelsResponse);
                            stopWhile = modelsResponse.Any();
                        }
                        else
                        {
                            stopWhile = false;
                            result.AddApiConsumeError("erro consuming api webmotors" + response.StatusCode.ToString());
                        }
                        
                        page++;
                    } while (stopWhile);


                    result.Vehicles = vehicles;

                    _cache.SetString(redisInternalKey, JsonConvert.SerializeObject(result),
                    new DistributedCacheEntryOptions().SetAbsoluteExpiration(CacheTimeOut));


                }
            }
            catch (Exception ex)
            {
                result.AddSystemError(ex);
            }

            return result;
        }

        public async Task<Results.GetVehicleVersionResult> ListVehicleVersions(int modelId)
        {
            var result = new Results.GetVehicleVersionResult();
            try
            {
                var redisInternalKey = $"{nameof(VehiclesRepository)}-{nameof(Results.GetVehicleVersionResult)}";
                //check value on redis cache
                string jsonValue = _cache.GetString(redisInternalKey);


                if (!string.IsNullOrEmpty(jsonValue))
                {
                    result = JsonConvert.DeserializeObject<Results.GetVehicleVersionResult>(jsonValue);

                    return result;
                }

                var root = _config.GetValue<string>(EnviromentConstants.VERSION_ROOT.GetName());

                var param = $"?ModelID={modelId}";

                using (var httpClient = _httpClientFactory.CreateClient(_clientName))
                {
                    
                    var request = new HttpRequestMessage(HttpMethod.Get, root + param);

                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var modelsResponse = await response.Content.ReadAsAsync<IEnumerable<VehicleVersionModel>>();

                        result.VehicleVersions = modelsResponse;

                        _cache.SetString(redisInternalKey, JsonConvert.SerializeObject(result),
                        new DistributedCacheEntryOptions().SetAbsoluteExpiration(CacheTimeOut));
                    }

                }
            }
            catch (Exception ex)
            {
                result.AddSystemError(ex);
            }

            return result;
        }
    }
}
