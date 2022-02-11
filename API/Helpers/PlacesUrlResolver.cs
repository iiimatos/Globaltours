using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
  public class PlacesUrlResolver : IValueResolver<Place, PlaceDto, string>
  {
    private readonly IConfiguration _config;
    public PlacesUrlResolver(IConfiguration config)
    {
      _config = config;
    }
    public string Resolve(Place source, PlaceDto destination, string destMember, ResolutionContext context)
    {
      if (!string.IsNullOrEmpty(source.ImageUrl))
      {
        return $"{_config["ApiUrl"]}{source.ImageUrl}";
      }
      return null;
    }
  }
}