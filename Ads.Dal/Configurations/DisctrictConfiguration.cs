using Ads.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations
{
  public class DisctrictConfiguration : IEntityTypeConfiguration<District>
  {

    public void Configure(EntityTypeBuilder<District> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(70)");

      builder.HasData(
       new District { Id = 1, Name = "Odunpazarı", CityId = 1 },
       new District { Id = 2, Name = "Tepebaşı", CityId = 1 },
       new District { Id = 3, Name = "Beşiktaş", CityId = 2 },
       new District { Id = 4, Name = "Beyoğlu", CityId = 2 },
       new District { Id = 5, Name = "Çankaya", CityId = 3 },
       new District { Id = 6, Name = "Sincan", CityId = 3 },
       new District { Id = 7, Name = "Bayraklı", CityId = 4 },
       new District { Id = 8, Name = "Foça", CityId = 4 },
       new District { Id = 9, Name = "Çukurova", CityId = 5 },
       new District { Id = 10, Name = "Seyhan", CityId = 5 }
       );
    }
  }
}
