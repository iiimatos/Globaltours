using Core.Entities;

namespace Core.Interfaces
{
  public interface IPlaceRepository
  {
    Task<Place> GetPlaceByIdAsync(int id);
    Task<IReadOnlyList<Place>> GetAllPlacesAsync();
  }
}