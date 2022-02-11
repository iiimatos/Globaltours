using Core.Entities;

namespace Core.Specification
{
  public class PlacesWithCountriesAndCategoriesSpecification : SpecificationBase<Place>
  {
    public PlacesWithCountriesAndCategoriesSpecification()
    {
      IncludeAdd(x => x.Country);
      IncludeAdd(x => x.Category);
    }

    public PlacesWithCountriesAndCategoriesSpecification(int id) : base(x => x.Id == id)
    {
      IncludeAdd(x => x.Country);
      IncludeAdd(x => x.Category);
    }
  }
}