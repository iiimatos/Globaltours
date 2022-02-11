using System.Linq.Expressions;

namespace Core.Specification
{
  public class SpecificationBase<T> : ISpecification<T>
  {
    public SpecificationBase()
    { }
    public SpecificationBase(Expression<Func<T, bool>> filter)
    {
      Filter = filter;
    }

    public Expression<Func<T, bool>> Filter { get; }

    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

    protected void IncludeAdd(Expression<Func<T, object>> includesExpression)
    {
      Includes.Add(includesExpression);
    }
  }
}