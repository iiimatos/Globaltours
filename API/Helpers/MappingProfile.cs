using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Place, PlaceDto>()
          .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.Name))
          .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
          .ForMember(d => d.ImageUrl, o => o.MapFrom<PlacesUrlResolver>());
    }
  }
}