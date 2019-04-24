using Kernel.Core.Utils;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Results
{
    public class GetVehiclesResult : ResultBase
    {

        public IEnumerable<VehicleModel> Vehicles { get; set; }
        



    }
}
