using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Results
{
    public class GetVehicleVersionResult : Kernel.Core.Utils.ResultBase
    {
        public IEnumerable<VehicleVersionModel> VehicleVersions { get; set; }

    }
}
