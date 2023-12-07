using Ads.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations
{
	public class AdvertCommentConfiguration : IEntityTypeConfiguration<AdvertComment>
	{
		public void Configure(EntityTypeBuilder<AdvertComment> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(a => a.Comment).IsRequired().HasColumnType("text");

			builder
			.HasOne(ac => ac.User)
			.WithMany(u => u.AdvertComments)
			.HasForeignKey(ac => ac.UserId)
			.OnDelete(DeleteBehavior.Restrict);

			builder.HasData(
		new AdvertComment { Id = 1, Comment = "Kargo hızlı geldi. Çok memnun kaldım", AdvertId = 1, UserId = 3, StarCount = 5 },
		new AdvertComment { Id = 2, Comment = "Ürün hiç beklediğim gibi değildi. Hiç beğenmedim", AdvertId = 3, UserId = 3, StarCount = 1 },
		new AdvertComment { Id = 3, Comment = "Ürün çok kötüydü. Hiç beğenmedim", AdvertId = 3, UserId = 4, StarCount = 2 },
		new AdvertComment { Id = 4, Comment = "Bu nasıl bir ürün, ben böyle bir şey görmemişim.", AdvertId = 2, UserId = 4, StarCount = 1 },
		new AdvertComment { Id = 5, Comment = "Ürün görüldüğü gibiydi.", AdvertId = 2, UserId = 7, StarCount = 4 },
		new AdvertComment { Id = 6, Comment = "Güzel paketlenmişti.", AdvertId = 3, UserId = 5, StarCount = 4 },
		new AdvertComment { Id = 7, UserId = 5, AdvertId = 6, StarCount = 3, Comment = "Fiyat performans bekledik fos çıktı !" }
);
		}


	}
}
