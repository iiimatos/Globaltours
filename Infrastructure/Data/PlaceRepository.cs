using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class PlaceRepository : IPlaceRepository
  {
    private readonly ApplicationDbContext _db;
    public PlaceRepository(ApplicationDbContext db)
    {
      _db = db;
    }
    public async Task<IReadOnlyList<Place>> GetAllPlacesAsync()
    {
      return await _db.Places.Include(p => p.Country).Include(p => p.Category).ToListAsync();
    }

    public async Task<Place> GetPlaceByIdAsync(int id)
    {
      return await _db.Places.Include(p => p.Country).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
    }
  }
}