using Ads.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Dal.Configurations
{
  public class AdvertImageConfiguration : IEntityTypeConfiguration<AdvertImage>
  {
    public void Configure(EntityTypeBuilder<AdvertImage> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(ai => ai.ImagePath).IsRequired().HasColumnType("nvarchar(200)");

      builder
        .HasOne(ai => ai.Advert)
        .WithMany(a => a.AdvertImages)
        .HasForeignKey(ai => ai.AdvertId)
        .OnDelete(DeleteBehavior.Restrict);
        //TODO: Images will be altered once the categories are determened
      builder.HasData(
      new AdvertImage { Id = 1, ImagePath = "http://via.placeholder.com/610x400/lamp", AdvertId = 1 },
    new AdvertImage { Id = 2, ImagePath = "http://via.placeholder.com/610x400/lamp", AdvertId = 1 },
    new AdvertImage { Id = 3, ImagePath = "http://via.placeholder.com/610x400/lamp", AdvertId = 1 },

    new AdvertImage { Id = 4, ImagePath = "http://via.placeholder.com/610x400/table", AdvertId = 2 },
    new AdvertImage { Id = 5, ImagePath = "http://via.placeholder.com/610x400/table", AdvertId = 2 },
    new AdvertImage { Id = 6, ImagePath = "http://via.placeholder.com/610x400/table", AdvertId = 2 },

    new AdvertImage { Id = 7, ImagePath = "https://example.com/image1.jpg", AdvertId = 3 },
    new AdvertImage { Id = 8, ImagePath = "https://example.com/image2.jpg", AdvertId = 3 },
    new AdvertImage { Id = 9, ImagePath = "https://example.com/image3.jpg", AdvertId = 3 },

    new AdvertImage { Id = 10, ImagePath = "https://example.com/image1.jpg", AdvertId = 4 },
    new AdvertImage { Id = 11, ImagePath = "https://example.com/image2.jpg", AdvertId = 4 },
    new AdvertImage { Id = 12, ImagePath = "https://example.com/image3.jpg", AdvertId = 4 },

    new AdvertImage { Id = 13, ImagePath = "https://example.com/image1.jpg", AdvertId = 5 },
    new AdvertImage { Id = 14, ImagePath = "https://example.com/image2.jpg", AdvertId = 5 },
    new AdvertImage { Id = 15, ImagePath = "https://example.com/image3.jpg", AdvertId = 5 },

    new AdvertImage { Id = 16, ImagePath = "https://example.com/image1.jpg", AdvertId = 6 },
    new AdvertImage { Id = 17, ImagePath = "https://example.com/image2.jpg", AdvertId = 6 },
    new AdvertImage { Id = 18, ImagePath = "https://example.com/image3.jpg", AdvertId = 6 },

    new AdvertImage { Id = 19, ImagePath = "https://example.com/image1.jpg", AdvertId = 7 },
    new AdvertImage { Id = 20, ImagePath = "https://example.com/image2.jpg", AdvertId = 7 },
    new AdvertImage { Id = 21, ImagePath = "https://example.com/image3.jpg", AdvertId = 7 },

    new AdvertImage { Id = 22, ImagePath = "https://example.com/image1.jpg", AdvertId = 8 },
    new AdvertImage { Id = 23, ImagePath = "https://example.com/image2.jpg", AdvertId = 8 },
    new AdvertImage { Id = 24, ImagePath = "https://example.com/image3.jpg", AdvertId = 8 },

    new AdvertImage { Id = 25, ImagePath = "https://example.com/image1.jpg", AdvertId = 9 },
    new AdvertImage { Id = 26, ImagePath = "https://example.com/image2.jpg", AdvertId = 9 },
    new AdvertImage { Id = 27, ImagePath = "https://example.com/image3.jpg", AdvertId = 9 },

    new AdvertImage { Id = 28, ImagePath = "https://example.com/image1.jpg", AdvertId = 10 },
    new AdvertImage { Id = 29, ImagePath = "https://example.com/image2.jpg", AdvertId = 10 },
    new AdvertImage { Id = 30, ImagePath = "https://example.com/image3.jpg", AdvertId = 10 }
      ) ;
    }

    private List<AdvertImage> GetFakeAdvertImages()
    {
      var fakeAdvertImages = new List<AdvertImage>();

      var faker = new Bogus.Faker<AdvertImage>()
          .RuleFor(ai => ai.ImagePath, f => f.Image.LoremFlickrUrl(width:610, height:399,keywords:"product"))
          .RuleFor(ai => ai.AdvertId, f => f.Random.Number(1, 10));

      for (int i = 1; i <= 10; i++)
      {
        var fakeAdvertImage = faker.Generate();
        fakeAdvertImage.Id = i;
        fakeAdvertImages.Add(fakeAdvertImage);
      }

      return fakeAdvertImages;
    }
  }
}
