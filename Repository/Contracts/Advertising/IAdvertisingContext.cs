using Repository.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts.Advertising
{
    public interface IAdvertisingRepository
    {
        Task<GetAdvertisingResult> GetById(Guid id);




    }
}
