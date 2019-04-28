using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contexts
{
    public class GenericContext<TModel> : IWriteContext<TModel> where TModel : class
    {
        protected MySqlContext Context;
        protected DbSet<TModel> DbSet;

        public GenericContext(MySqlContext context)
        {
            Context = context;
            DbSet = Context.Set<TModel>();
        }

        public virtual async Task<TModel> Add(TModel obj)
        {
            var entry = await DbSet.AddAsync(obj);
            return entry.Entity;
        }

        public virtual async Task<TModel> Update(TModel obj)
        {
            await Task.Run(() =>
            {
                var entry = Context.Entry(obj);
                DbSet.Attach(obj);
                entry.State = EntityState.Modified;
            });

            return obj;
        }


        public virtual async Task Remove(TModel obj)
        {
            await Task.Run(() => DbSet.Remove(obj));
        }

        public virtual async Task<IEnumerable<TModel>> FindWhere(Expression<Func<TModel, bool>> predicate)
        {
            return (await Task.Run(() => DbSet.Where(predicate) as IEnumerable<TModel>));
            
        }

        public Task<int> Save()
        {
            return Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
