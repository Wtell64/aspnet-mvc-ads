using Ads.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations
{
  public class AddressConfiguration : IEntityTypeConfiguration<Address>
  {


    public void Configure(EntityTypeBuilder<Address> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Country).IsRequired().HasColumnType("nvarchar(70)");
      builder.Property(c => c.PostCode).IsRequired().HasColumnType("nvarchar(20)");
      builder.Property(c => c.DetailedAddress).IsRequired().HasColumnType("nvarchar(300)");

      builder
      .HasOne(ac => ac.District)
      .WithMany(u => u.Addresses)
      .HasForeignKey(ac => ac.DistrictId)
      .OnDelete(DeleteBehavior.Restrict);

      builder.HasData(
      new Address { Id = 1, UserId = 3, CityId = 1, DistrictId = 1, PostCode = "341449", Country = "Türkiye", DetailedAddress = "Emin Sokak" },
      new Address { Id = 2, UserId = 4, CityId = 2, DistrictId = 3, PostCode = "25123", Country = "Türkiye", DetailedAddress = "Kerem Sokak Kus Apartmani" },
      new Address { Id = 3, UserId = 5, CityId = 4, DistrictId = 7, PostCode = "26120", Country = "Türkiye", DetailedAddress = "Reşadiye cami üstü" },
      new Address { Id = 4, UserId = 6, CityId = 5, DistrictId = 10, PostCode = "01240", Country = "Türkiye", DetailedAddress = "Akşemsettin Mahallesi" },
      new Address { Id = 5, UserId = 7, CityId = 3, DistrictId = 6, Country = "Türkiye", PostCode = "06810", DetailedAddress = "Odabaşı Cd." }
      );
    }
  }
}
