using Kernel.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Results
{
    public class GetAdvertisingResult : ResultBase 
    {
        public IEnumerable<Models.AdvertisingModel> Advertisings { get; set; }

        public int AffectedItems { get; set; }

    }

}
