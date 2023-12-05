using Ads.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations
{
	public class PageConfiguration : IEntityTypeConfiguration<Page>
	{
		//TODO: Önerilere göre geliştirilebilir.
		public void Configure(EntityTypeBuilder<Page> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Title).IsRequired().HasColumnType("nvarchar(200)");
			builder.Property(p => p.Content).IsRequired();
		}
	}
}
