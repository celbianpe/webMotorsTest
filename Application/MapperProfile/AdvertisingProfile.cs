using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MapperProfile
{
    public class AdvertisingProfile : Profile
    {

        public AdvertisingProfile()
        {
            // dto para model
            CreateMap<Dtos.AdvertisingDto, Repository.Models.AdvertisingModel>().ReverseMap();


        }
    }
}
