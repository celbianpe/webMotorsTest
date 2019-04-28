using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Contexts;
using Repository.Results;

namespace Repository.Implements
{
    public class AdvertisingRepository : GenericContext<Models.AdvertisingModel>, Contracts.Advertising.IAdvertisingRepository
    {


        public AdvertisingRepository(MySqlContext context) : base(context)
        {
        }

        
        public async Task<Results.AddAdvertisingResult> Create(Models.AdvertisingModel model)
        {
            var result = new AddAdvertisingResult();
            try
            {
                await Add(model);
                result.AffectedItem = await Save();
                
            }
            catch (Exception ex)
            {
                result.AddSystemError(ex);
            }

            return result;
        }

        public async Task<Results.GetAdvertisingResult> List()
        {
            var result = new GetAdvertisingResult();
            try
            {
                var resultQuery = await FindWhere(t=> true);

                result.Advertisings = resultQuery;

            }
            catch (Exception ex)
            {
                result.AddSystemError(ex);
            }

            return result;
        }

        public async Task<Results.UpdateAdvertisingResult> UpdateItem(Models.AdvertisingModel model)
        {
            var result = new UpdateAdvertisingResult();
            try
            {
                var resultQuery = await Update(model);

                var affectedItem = await Save();

                var UpdatedItem = await FindWhere(u => u.Id == model.Id);

                result.Advertisings = UpdatedItem;

                result.AffectedItems = affectedItem;

            }
            catch (Exception ex)
            {
                result.AddSystemError(ex);
            }

            return result;
        }

        public async Task<Results.RemoveAdvertisingResult> RemoveItem(int advertisingId)
        {
            var result = new RemoveAdvertisingResult();
            try
            {

                var RemovedItem = await FindWhere(u => u.Id == advertisingId);

                if (RemovedItem.Any())
                {

                    await Remove(RemovedItem.FirstOrDefault());

                    var affectedItem = await Save();

                    result.AffectedItems = affectedItem;

                }

                result.AddSystemError("Advertising not found on database...");
                result.AffectedItems = 0;

            }
            catch (Exception ex)
            {
                result.AddSystemError(ex);
            }

            return result;
        }

    }
}
