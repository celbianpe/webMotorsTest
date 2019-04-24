using Kernel.Core.Utils;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Results
{
    public class GetVehicleModelsResult : ResultBase
    {

        public IEnumerable<VehicleModelModel>  VehicleModels { get; set; }
        


    }
}
