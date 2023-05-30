using AutoMapper;
using Roa.Application.DTOs;
using Roa.Domain.Entities;

namespace Roa.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<Dish, DishDto>().ReverseMap();
            CreateMap<DishType, DishTypeDto>().ReverseMap();
            CreateMap<Period, PeriodDto>().ReverseMap();
        }
    }
}
