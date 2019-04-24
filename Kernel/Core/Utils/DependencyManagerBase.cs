using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.Core.Utils
{
    public class DependencyManagerBase<T> where T : DependencyManagerBase<T>
    {
        protected readonly IConfiguration Configuration;
        protected readonly IServiceCollection Services;

        public DependencyManagerBase(IServiceCollection services, IConfiguration configuration)
        {
            Services = services;
            Configuration = configuration;
        }

        public virtual T Build()
        {
            AddConfigurations();
            AddDbContexts();
            AddRepositories();
            AddExternalServices();
            AddDomainServices();
            AddApplicationCache();
            return this as T;
        }

        public virtual T AddExternalServices()
        {
            throw new NotSupportedException();
        }

        public virtual T AddApplicationCache()
        {
            throw new NotSupportedException();
        }

        public virtual T AddDomainServices()
        {
            throw new NotSupportedException();
        }

        public virtual T AddConfigurations()
        {
            throw new NotSupportedException();
        }

        public virtual T AddDbContexts()
        {
            throw new NotSupportedException();
        }

        public virtual T AddRepositories()
        {
            throw new NotSupportedException();
        }


        public virtual T AddApplicationMembers()
        {
            throw new NotSupportedException();

        }


    }
}
