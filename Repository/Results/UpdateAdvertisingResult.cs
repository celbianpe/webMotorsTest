using Kernel.Core.Utils;
using System.Collections.Generic;

namespace Repository.Results
{
    public class UpdateAdvertisingResult : ResultBase
    {
        public IEnumerable<Models.AdvertisingModel> Advertisings { get; set; }

        public int AffectedItems { get; set; }

    }

}
