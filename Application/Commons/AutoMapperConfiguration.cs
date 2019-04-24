using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Commons
{
    public class AutoMapperConfiguration
    {
        public static readonly AutoMapperConfiguration Instance = new AutoMapperConfiguration();

        static AutoMapperConfiguration() { }

        public static void Initialize() { }

        private AutoMapperConfiguration()
        {
            Mapper.Initialize(Configure);
            Mapper.Configuration.CompileMappings();
            Mapper.AssertConfigurationIsValid();
        }

        private static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.Advanced.AllowAdditiveTypeMapCreation = true;

            cfg.AddProfile(new MapperProfile.BaseProfile());
     
        }
    }
}
