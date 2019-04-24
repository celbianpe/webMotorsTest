using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contexts
{
    public class MySqlContext : DbContext 
    {
        public MySqlContext(DbContextOptions options) : base(options) { }

        public DbSet<Models.AdvertisingModel> Advertising { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdvertisingModelMapper());
            

            base.OnModelCreating(builder);
        }


    }
}
