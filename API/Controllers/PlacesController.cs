using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PlacesController : ControllerBase
  {
    private readonly IPlaceRepository _repo;
    public PlacesController(IPlaceRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Place>>> GetPlaces()
    {
      var places = await _repo.GetAllPlacesAsync();
      return Ok(places);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Place>> GetPlace(int id)
    {
      return await _repo.GetPlaceByIdAsync(id);
    }
  }
}