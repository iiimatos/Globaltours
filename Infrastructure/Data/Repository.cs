using Core.Interfaces;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly ApplicationDbContext _db;
    public Repository(ApplicationDbContext db)
    {
      _db = db;
    }
    public async Task<IReadOnlyList<T>> GetAllDataAsync()
    {
      return await _db.Set<T>().ToListAsync();
    }
    public async Task<T> GetDataByIdAsync(int id)
    {
      return await _db.Set<T>().FindAsync(id);
    }
    public async Task<T> GetSpecById(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).FirstOrDefaultAsync();
    }
    public async Task<IReadOnlyList<T>> GetAllSpec(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).ToListAsync();
    }
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
      return SpecificationEvaluator<T>.GetQuery(_db.Set<T>().AsQueryable(), spec);
    }
  }
}