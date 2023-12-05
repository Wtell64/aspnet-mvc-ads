using Ads.Entities.Concrete;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Ads.Dal.Configurations
{
  public class CategoryConfiguration : IEntityTypeConfiguration<Category>
  {
    private static int startId = 1;

    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(100)");
      builder.Property(c => c.Description).IsRequired().HasColumnType("nvarchar(300)");

      
      //builder
      //.HasMany(c => c.CategoryAdverts)
      //.WithOne(ca => ca.Category)
      //.HasForeignKey(ca => ca.CategoryId)     
      //.OnDelete(DeleteBehavior.Cascade);


      var categoryFaker = new Faker<Category>("tr")
      .RuleFor(p => p.Id, f => startId++)
      .RuleFor(p => p.Name, f => f.Commerce.Categories(1)[0])
      .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
      ;

      var generatedCategories = categoryFaker.Generate(10);

      builder.HasData(generatedCategories);

      //var predefinedCategories = new List<string> { "Tools", "Home", "Baby", "Games" };

      //var categoryFaker = new Faker<Category>("tr")
      //    .RuleFor(p => p.Id, f => f.IndexFaker + 1)
      //    .RuleFor(p => p.Name, f => f.PickRandom(predefinedCategories))
      //    .RuleFor(p => p.Description, f => f.Commerce.ProductDescription());

      //var generatedCategories = categoryFaker.Generate(10);

      //builder.HasData(generatedCategories);

    }
  }
}
