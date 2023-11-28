using Ads.Entities.Concrete;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations
{
  public class AddressConfiguration : IEntityTypeConfiguration<Address>
  {
    //TODO: kaç kullanıcı üretileceğini bilmediğim için UserID vermedim. User oluşturulduktan sonra burasının oluşturulması gerekiyor, user confige taşıyabiliriz.
    private static int startId = 1;

    public void Configure(EntityTypeBuilder<Address> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Country).IsRequired().HasColumnType("nvarchar(70)");
      builder.Property(c => c.PostCode).IsRequired().HasColumnType("nvarchar(20)");
      builder.Property(c => c.DetailedAddress).IsRequired().HasColumnType("nvarchar(300)");

      var addressFaker = new Faker<Address>("tr")
      .RuleFor(p => p.Id, f => startId++)
      .RuleFor(p => p.Country, f => f.Address.Country())
      .RuleFor(p => p.PostCode, f => f.Address.ZipCode())
      .RuleFor(p => p.DetailedAddress, f => f.Address.FullAddress())
      ;

      var generatedAddress = addressFaker.Generate(10);

      builder.HasData(generatedAddress);
    }
  }
}
