using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PlacesController : ControllerBase
  {
    private readonly ApplicationDbContext _db;
    public PlacesController(ApplicationDbContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Place>>> GetPlaces()
    {
      var places = await _db.Places.ToListAsync();
      return places;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Place>> GetPlace(int id)
    {
      return await _db.Places.FindAsync(id);
    }
  }
}