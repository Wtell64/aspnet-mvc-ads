using Ads.Entities.Concrete;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations
{
  public class CategoryAdvertConfiguration : IEntityTypeConfiguration<CategoryAdvert>
  {
    public void Configure(EntityTypeBuilder<CategoryAdvert> builder)
    {
      builder.HasKey(ca=> new {ca.CategoryId, ca.AdvertId});

      //builder
      //.HasOne(ca => ca.Category)
      //.WithMany(c => c.CategoryAdverts)
      //.HasForeignKey(ca => ca.CategoryId)
      //.OnDelete(DeleteBehavior.Cascade);

      //builder
      //.HasOne(ca => ca.Advert)
      //.WithMany(a => a.CategoryAdverts)
      //.HasForeignKey(ca=>ca.AdvertId)
      //.OnDelete(DeleteBehavior.Cascade);

      //var categoryAdvertFaker = new Faker<CategoryAdvert>()
      //.RuleFor(ca => ca.CategoryId, f => f.Random.Number(1, 10))
      //.RuleFor(ca => ca.AdvertId, f => f.Random.Number(1, 10));

      //var generetedcategoryadvertFaker= categoryAdvertFaker.Generate(10);
      //builder.HasData(generetedcategoryadvertFaker);



    }

  }
}
