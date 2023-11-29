using Ads.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations
{
  public class CityConfiguration : IEntityTypeConfiguration<City>
  {

    public void Configure(EntityTypeBuilder<City> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(70)");

      builder.HasData(
      new City { Id = 1, Name = "Eskişehir" },
      new City { Id = 2, Name = "İstanbul" },
      new City { Id = 3, Name = "Ankara" },
      new City { Id = 4, Name = "İzmir" },
      new City { Id = 5, Name = "Adana" }
      );

    }
  }
}
