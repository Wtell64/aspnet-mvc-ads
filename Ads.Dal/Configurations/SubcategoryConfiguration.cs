using Ads.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Dal.Configurations
{
	public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
	{
		public void Configure(EntityTypeBuilder<Subcategory> builder)
		{
			builder.Property(s => s.Name).IsRequired().HasColumnType("nvarchar(100)");
			builder.HasKey(s => s.Id);

			builder.HasData(new Subcategory { Id = 1, CategoryId = 1, Name = "Laptop"  },
			new Subcategory { Id = 2, CategoryId = 1, Name = "Telefon" },
			new Subcategory { Id = 3, CategoryId = 1, Name = "Tablet" },
			new Subcategory { Id = 4, CategoryId = 1, Name = "Ekran" },
			new Subcategory { Id = 5, CategoryId = 2, Name = "Kafe" },
			new Subcategory { Id = 6, CategoryId = 2, Name = "Fast Food" },
			new Subcategory { Id = 7, CategoryId = 2, Name = "Restoran" },
			new Subcategory { Id = 8, CategoryId = 2, Name = "Yöresel Yemekler" },
			new Subcategory { Id = 9, CategoryId = 3, Name = "Arsa" },
			new Subcategory { Id = 10, CategoryId = 3, Name = "Spor Salonu" },
			new Subcategory { Id = 11, CategoryId = 3, Name = "Hastane" },
			new Subcategory { Id = 12, CategoryId = 3, Name = "Ev" },
			new Subcategory { Id = 13, CategoryId = 4, Name = "Erkek Giysileri" },
			new Subcategory { Id = 14, CategoryId = 4, Name = "Aksesuarlar" },
			new Subcategory { Id = 15, CategoryId = 4, Name = "Çocuk Giysileri" },
			new Subcategory { Id = 16, CategoryId = 4, Name = "Yazılım" },
			new Subcategory { Id = 17, CategoryId = 5, Name = "Muhasebe" },
			new Subcategory { Id = 18, CategoryId = 5, Name = "Kombi Tamiri" },
			new Subcategory { Id = 19, CategoryId = 5, Name = "Özel Ders" },
			new Subcategory { Id = 20, CategoryId = 5, Name = "Boyacı" },
			new Subcategory { Id = 21, CategoryId = 6, Name = "Otobüs" },
			new Subcategory { Id = 22, CategoryId = 6, Name = "Araç" },
			new Subcategory { Id = 23, CategoryId = 6, Name = "Motorsiklet" },
			new Subcategory { Id = 24, CategoryId = 6, Name = "Yat" },
			new Subcategory { Id = 25, CategoryId = 7, Name = "Kedi Ürünleri" },
			new Subcategory { Id = 26, CategoryId = 7, Name = "Köpek Ürünleri" },
			new Subcategory { Id = 27, CategoryId = 7, Name = "Kuş Ürünleri" },
			new Subcategory { Id = 28, CategoryId = 7, Name = "Balık Ürünleri" },
			new Subcategory { Id = 29, CategoryId = 8, Name = "Temizlik" },
			new Subcategory { Id = 30, CategoryId = 8, Name = "Araba Yıkama" },
			new Subcategory { Id = 31, CategoryId = 8, Name = "Kuru Temizleme" },
			new Subcategory { Id = 32, CategoryId = 8, Name = "Cenaze" }
);
		}
			
	}
}
