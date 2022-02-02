using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
  public class SeedDataBase
  {
    public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
    {
      try
      {
        if (!context.Countries.Any())
        {
          var dataCountries = File.ReadAllText("../Infrastructure/Data/SeedData/countries.json");
          var countries = JsonSerializer.Deserialize<List<Country>>(dataCountries);
          foreach (var country in countries)
          {
            await context.Countries.AddAsync(country);
          }
          await context.SaveChangesAsync();
        }
        if (!context.Categories.Any())
        {
          var dataCategories = File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");
          var categories = JsonSerializer.Deserialize<List<Category>>(dataCategories);
          foreach (var category in categories)
          {
            await context.Categories.AddAsync(category);
          }
          await context.SaveChangesAsync();
        }
        if (!context.Places.Any())
        {
          var dataPlaces = File.ReadAllText("../Infrastructure/Data/SeedData/places.json");
          var places = JsonSerializer.Deserialize<List<Place>>(dataPlaces);
          foreach (var place in places)
          {
            await context.Places.AddAsync(place);
          }
          await context.SaveChangesAsync();
        }
      }
      catch (System.Exception ex)
      {
        var logger = loggerFactory.CreateLogger<SeedDataBase>();
        logger.LogError(ex.Message);
      }
    }
  }
}