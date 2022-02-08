using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PlacesController : ControllerBase
  {
    private readonly IRepository<Place> _placeRepo;
    private readonly IRepository<Country> _countryRepo;
    private readonly IRepository<Category> _categoryRepo;
    private readonly IMapper _mapper;
    public PlacesController(IRepository<Place> placeRepo, IRepository<Country> countryRepo, IRepository<Category> categoryRepo, IMapper mapper)
    {
      _mapper = mapper;
      _categoryRepo = categoryRepo;
      _countryRepo = countryRepo;
      _placeRepo = placeRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PlaceDto>>> GetPlaces()
    {
      var spec = new PlacesWithCountriesAndCategoriesSpecification();
      var places = await _placeRepo.GetAllSpec(spec);
      return Ok(_mapper.Map<IReadOnlyList<Place>, IReadOnlyList<PlaceDto>>(places));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlaceDto>> GetPlace(int id)
    {
      var spec = new PlacesWithCountriesAndCategoriesSpecification(id);
      var place = await _placeRepo.GetSpecById(spec);
      return _mapper.Map<Place, PlaceDto>(place);
    }

    [HttpGet("countries")]
    public async Task<ActionResult<List<Country>>> GetCountries()
    {
      return Ok(await _countryRepo.GetAllDataAsync());
    }

    [HttpGet("categories")]
    public async Task<ActionResult<List<Category>>> GetCategory()
    {
      return Ok(await _categoryRepo.GetAllDataAsync());
    }
  }
}