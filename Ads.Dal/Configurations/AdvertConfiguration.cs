using Ads.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Bogus;

namespace Ads.Dal.Configurations
{
  public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
  {


    public void Configure(EntityTypeBuilder<Advert> builder)
    {
      // Configure properties
      builder.Property(a => a.Title).IsRequired().HasColumnType("nvarchar(200)");
      builder.Property(a => a.Description).IsRequired().HasColumnType("ntext");
      builder.Property(a => a.Price).IsRequired();
      builder.HasKey(c => c.Id);

      builder
          .HasMany(a => a.AdvertComments)
          .WithOne(ac => ac.Advert)
          .OnDelete(DeleteBehavior.Cascade);

      builder
          .HasMany(a => a.AdvertImages)
          .WithOne(ai => ai.Advert)
          .OnDelete(DeleteBehavior.Cascade);

      builder
        .HasOne(a => a.User)
        .WithMany(u => u.Adverts)
        .HasForeignKey(a => a.UserId)
        .OnDelete(DeleteBehavior.Restrict);

      builder
        .HasMany(a => a.CategoryAdverts)
        .WithOne(ca => ca.Advert)
        .HasForeignKey(ca => ca.AdvertId)
        .OnDelete(DeleteBehavior.Cascade);



      builder.HasData(
          new Advert { Id = 1, Title = "Black Lamp", Price = 40, UserId = 3, Description = "A stylish black lamp for your home." },
          new Advert { Id = 2, Title = "Wooden Table", Price = 80, UserId = 3, Description = "A sturdy wooden table perfect for dining or work." },
          new Advert { Id = 3, Title = "Red Chair", Price = 30, UserId = 3, Description = "Comfortable red chair for your living room." },
          new Advert { Id = 4, Title = "Camera Kit", Price = 500, UserId = 3, Description = "Professional camera kit for photography enthusiasts." },
          new Advert { Id = 5, Title = "Bookshelf", Price = 60, UserId = 3, Description = "A spacious bookshelf to organize your books." },
          new Advert { Id = 6, Title = "Coffee Maker", Price = 100, UserId = 3, Description = "High-quality coffee maker for coffee lovers." },
          new Advert { Id = 7, Title = "Desk Organizer", Price = 25, UserId = 3, Description = "Keep your desk tidy with this organizer." },
          new Advert { Id = 8, Title = "Smartphone Stand", Price = 15, UserId = 3, Description = "Convenient smartphone stand for hands-free use." },
          new Advert { Id = 9, Title = "Leather Wallet", Price = 50, UserId = 3, Description = "Elegant leather wallet for your essentials." },
          new Advert { Id = 10, Title = "Fitness Tracker", Price = 60, UserId = 3, Description = "Stay fit with this advanced fitness tracker." }
      );


      //builder.HasData(GetFakeAdverts(20));
    }

    private List<Advert> GetFakeAdverts(int n)
    {
      var fakeAdverts = new List<Advert>();

      var faker = new Faker<Advert>("tr")
        .RuleFor(a => a.Title, f => f.Commerce.ProductName())
        .RuleFor(a => a.Description, f => f.Commerce.ProductAdjective() + " " + f.Commerce.ProductMaterial())
        .RuleFor(a => a.Price, f => f.Random.Number(10, 1000))
        .RuleFor(a => a.UserId, 3);

      for (int i = 1; i <= n; i++)
      {
        var fakeAdvert = faker.Generate();
        fakeAdvert.Id = i;
        fakeAdverts.Add(fakeAdvert);
      }

      return fakeAdverts;
    }
  }
}
