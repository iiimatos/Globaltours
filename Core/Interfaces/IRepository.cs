using Core.Specification;

namespace Core.Interfaces
{
  public interface IRepository<T> where T : class
  {
    Task<T> GetDataByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllDataAsync();

    Task<T> GetSpecById(ISpecification<T> spec);
    Task<IReadOnlyList<T>> GetAllSpec(ISpecification<T> spec);
  }
}