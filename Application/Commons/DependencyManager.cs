using Domain;
using Kernel.Core;
using Kernel.Core.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Contexts;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Kernel.Core.Utils.EnumExtensions;

namespace Application.Commons
{
    public class DependencyManager : DependencyManagerBase<DependencyManager>
    {
        new readonly IConfiguration Configuration;
        new readonly IServiceCollection Services;

        public DependencyManager(IServiceCollection services, IConfiguration configuration) : base(services, configuration)
        {
            Services = services;
            Configuration = configuration;
        }


        public static DependencyManager SetUp(IServiceCollection services, IConfiguration configuration)
        {

            return new DependencyManager(services, configuration);
        }

        public override DependencyManager AddApplicationMembers()
        {
            Services.Scan(scan => scan.FromCallingAssembly());

            return this;
        }


        public override DependencyManager AddApplicationCache()
        {
            Services.AddDistributedRedisCache(options => {
                var cnn = Configuration.GetValue<string>(EnviromentConstants.REDIS_CNN.GetName());


                options.Configuration = cnn;

                options.ConfigurationOptions = new ConfigurationOptions() {
                    Password = Configuration.GetValue<string>(EnviromentConstants.REDIS_PASSWORD.GetName()),
                                        
                };

                options.ConfigurationOptions.EndPoints.Add(cnn);

                options.InstanceName = Configuration.GetValue<string>(EnviromentConstants.WEB_CLIENT.GetName());
            });

            return this;
        }


        public override DependencyManager AddConfigurations()
        {
            Services.Scan(scan => scan.FromCallingAssembly());


            return this;
        }

        public override DependencyManager AddDbContexts()
        {

            //Add database context Use Mysql not SQL server 
            Services.AddDbContext<MySqlContext>(
            options => options.UseMySql(BuildMysqlConnectionString(Configuration, "teste_webmotors")),
            ServiceLifetime.Transient, ServiceLifetime.Transient);

            return this;
        }



        private static string BuildMysqlConnectionString(IConfiguration config, string database)
        {
            var server = config.GetValue<string>(EnviromentConstants.RELATIONAL_HOST.GetName());
            var port = config.GetValue<string>(EnviromentConstants.RELATIONAL_PORT.GetName());
            var username = config.GetValue<string>(EnviromentConstants.RELATIONAL_USER.GetName());
            var password = config.GetValue<string>(EnviromentConstants.RELATIONAL_PASSWORD.GetName());

            var connectionString = $"Server={server};Port={port};Database={database};User={username};Password={password};";

            Console.WriteLine($"MySQL: {connectionString}");
            Debug.WriteLine($"MySQL: {connectionString}");

            return connectionString;
        }

        public override DependencyManager AddDomainServices()
        {
            Services.Scan(scan => scan.FromAssemblyOf<DomainRef>()
                                      //.AddClasses(classes => classes.AssignableTo<ICustomerService>()).As<ICustomerService>()
                                      //.AddClasses(classes => classes.AssignableTo<IUserService>()).As<IUserService>()
                                      );

            return this;
        }


        public override DependencyManager AddExternalServices()
        {

            var baseAddress = Configuration.GetValue<string>(EnviromentConstants.BASE_ADDRESS.GetName());
            var externalClientName = Configuration.GetValue<string>(EnviromentConstants.WEB_CLIENT.GetName());
            Services.AddHttpClient(externalClientName,c=> {
                c.BaseAddress = new Uri(baseAddress);
            });
            return this;  
        }

        public override DependencyManager AddRepositories()
        {
            Services.Scan(scan => scan.FromAssemblyOf<RepositoryRef>()
                                      .AddClasses(classes => classes.AssignableTo<Repository.Contracts.Advertising.IAdvertisingRepository>()).As<Repository.Contracts.Advertising.IAdvertisingRepository>()
                                      .AddClasses(classes => classes.AssignableTo<Repository.Contracts.Vehicles.IVehicleRepository>()).As<Repository.Contracts.Vehicles.IVehicleRepository>()

            );
            
            return this;
        }
        
    }

}

