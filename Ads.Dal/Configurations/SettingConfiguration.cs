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
	public class SettingConfiguration : IEntityTypeConfiguration<Setting>
	{
		public void Configure(EntityTypeBuilder<Setting> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(200)");
			builder.Property(c => c.Value).IsRequired().HasColumnType("nvarchar(400)");

			builder.HasData(
				new Setting { Id = 1, UserId = 1, Name = "Sayfa Başına İlan Sayısı", Value = "50" },
				new Setting { Id = 2, UserId = 2, Name = "Sayfa Başına İlan Sayısı", Value = "20" },
				new Setting { Id = 3, UserId = 3, Name = "Sayfa Başına İlan Sayısı", Value = "10" },
				new Setting { Id = 4, UserId = 1, Name = "Karanlı Mod", Value = "Açık" });
		}
	}

}
