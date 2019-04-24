using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Repository.Results;

namespace Repository.Implements
{
    public class AdvertisingRepository : Contracts.Advertising.IAdvertisingRepository
    {

        public AdvertisingRepository()
        {

        }
        public Task<GetAdvertisingResult> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
