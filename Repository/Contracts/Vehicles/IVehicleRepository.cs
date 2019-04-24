using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts.Vehicles
{
    public interface IVehicleRepository
    {
        Task<Results.GetVehiclesResult> ListVehicles();

        Task<Results.GetVehicleMakesResult> ListVehicleMakes();

        Task<Results.GetVehicleModelsResult> ListVehicleModels(int makeId);

        Task<Results.GetVehicleVersionResult> ListVehicleVersions(int modelId);



    }
}
