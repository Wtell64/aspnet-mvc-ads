using Ads.Entities.Concrete;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations
{
  public class CategoryConfiguration : IEntityTypeConfiguration<Category>
  {
    private static int startId = 1;

    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(100)");
      builder.Property(c => c.Description).IsRequired().HasColumnType("nvarchar(200)");


      //builder
      //      .HasMany(c => c.ProductCategory)
      //      .WithOne(pc => pc.Category)
      //      .HasForeignKey(pc => pc.CategoryId)
      //      .OnDelete(DeleteBehavior.Restrict);


      var categoryFaker = new Faker<Category>("tr")
      .RuleFor(p => p.Id, f => startId++)
      .RuleFor(p => p.Name, f => f.Commerce.Categories(1)[0])
      .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
      //.RuleFor(p => p.SurName, f => f.Person.LastName)
      //.RuleFor(p => p.ImageUrl, f => emptyImageUrl)
      //.RuleFor(p => p.CardNumber, f => f.Random.String(12, 15, '0', '9'))
      //.RuleFor(p => p.StudentSchoolNumber, f => f.Random.String(2, 5, '0', '9'))
      //.RuleFor(p => p.SchoolClassId, f => f.PickRandom(schoolClasses).Id)
      ;

      var generatedCategories = categoryFaker.Generate(10);

      builder.HasData(generatedCategories);

    }
  }
}
