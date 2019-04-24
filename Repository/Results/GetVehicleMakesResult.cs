using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Results
{
    public class GetVehicleMakesResult : Kernel.Core.Utils.ResultBase
    {
        public IEnumerable<VehicleMakeModel> VehicleMakes { get; set; }
         
    }
}
