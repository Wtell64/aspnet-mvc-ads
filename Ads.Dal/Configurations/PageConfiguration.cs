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
			
			builder.HasKey(s => s.Id);

			builder.HasData(new Page { Id = 1, Title = "Hakkımızda", Content ="Bizim Hakkımızda Herşey Burada"},
			new Page { Id = 2, Title = "Bize Ulaşın", Content = "Bize Ulaşın ve Soru Sorun" });
		}
			
	}
}
