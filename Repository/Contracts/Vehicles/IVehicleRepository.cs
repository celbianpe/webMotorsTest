using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts.Vehicles
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Models.VehicleModel>> ListVehicles(int page);

        Task<Results.GetVehicleMakesResult> ListVehicleMakes();

        Task<Results.GetVehicleModelsResult> ListVehicleModels(int makeId);
        
        Task<IEnumerable<Models.VehicleVersionModel>> ListVehicleVersions(int modelId);


    }
}
