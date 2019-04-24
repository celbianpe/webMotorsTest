
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Commons
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var dependencyManager = DependencyManager.SetUp(services, configuration).Build();

            return services.AddSingleton(dependencyManager);
        }
    }
}
