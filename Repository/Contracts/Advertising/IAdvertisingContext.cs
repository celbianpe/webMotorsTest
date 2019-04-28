using Repository.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts.Advertising
{
    public interface IAdvertisingRepository
    {
        Task<Results.AddAdvertisingResult> Create(Models.AdvertisingModel model);

        Task<Results.UpdateAdvertisingResult> UpdateItem(Models.AdvertisingModel model);

        Task<Results.RemoveAdvertisingResult> RemoveItem(int advertisingId);


        Task<Results.GetAdvertisingResult> List();
    }
}
