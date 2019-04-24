using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MapperProfile
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<string, Guid>().ConvertUsing(s => GuidConverter(s));

            //CreateMap(typeof(ServiceResultBase), typeof(MessagingMeta));
        }

        private static Guid GuidConverter(string s)
        {
            Guid.TryParse(s, out var guid);
            return guid;
        }
    }
}
