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
	public class PageConfiguration : IEntityTypeConfiguration<Page>
	{

		public void Configure(EntityTypeBuilder<Page> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Title).IsRequired().HasColumnType("nvarchar(200)");
			builder.Property(p => p.Content).IsRequired();


			builder.HasData(new Page { Id = 1, Title = "Hakkımızda", Content ="Bizim Hakkımızda Herşey Burada"},
			new Page { Id = 2, Title = "Bize Ulaşın", Content = "Bize Ulaşın ve Soru Sorun" });
		}
	}
}
