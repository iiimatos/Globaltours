using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
  public class PlaceConfigurations : IEntityTypeConfiguration<Place>
  {
    public void Configure(EntityTypeBuilder<Place> builder)
    {
      builder.Property(p => p.Id).IsRequired();
      builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
      builder.Property(p => p.Description).IsRequired();
      builder.Property(p => p.ApproximateCost).IsRequired();

      /* RelationShips */
      builder.HasOne(c => c.Category).WithMany().HasForeignKey(p => p.CategoryId);
      builder.HasOne(c => c.Country).WithMany().HasForeignKey(p => p.CountryId);
    }
  }
}