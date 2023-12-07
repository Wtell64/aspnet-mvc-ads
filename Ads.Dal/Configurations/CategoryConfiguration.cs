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

      builder.Property(c => c.Description).IsRequired().HasColumnType("nvarchar(200)");

      builder.HasData(
      new Category { Id = 1, IconClass = "fa fa-laptop icon-bg-1", Name = "Elektronik", Description = "Elektronik araçların satıldığı kategoridir" },
      new Category { Id = 2, IconClass = "fa fa-apple icon-bg-2", Name = "Restoran", Description = "Restoranlarınız ile ilgili reklamları burda verebilirsiniz" },
			new Category { Id = 3, IconClass = "fa fa-home icon-bg-3", Name = "Emlak", Description = "Ev,arsa,dükkan." },
      new Category { Id = 4, IconClass = "fa fa-shopping-basket icon-bg-4", Name = "Alışveriş", Description = "7'den 70'e tüm ürünler." },
			new Category { Id = 5, IconClass = "fa fa-briefcase icon-bg-5", Name = "Meslekler", Description = "Kendi mesleğine göre ilan verebilirsin." },
      new Category { Id = 6, IconClass = "fa fa-car icon-bg-6", Name = "Araçlar", Description = "Aradığın araçlar burada" },
			new Category { Id = 7, IconClass = "fa fa-paw icon-bg-7", Name = "Pet Ürünleri", Description = "Evcil Hayvanlarınız İçin Herşey" },
			new Category { Id = 8, IconClass = "fa fa-laptop icon-bg-8", Name = "Hizmetler", Description = "Aradığınız hizmetler burada !" }
      );
		}
  }
}
