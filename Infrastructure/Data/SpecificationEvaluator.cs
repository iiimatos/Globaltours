using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class SpecificationEvaluator<T> where T : class
  {
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
    {
      var query = inputQuery;
      if (spec.Filter != null)
      {
        query = query.Where(spec.Filter);
      }
      query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
      return query;
    }
  }
}