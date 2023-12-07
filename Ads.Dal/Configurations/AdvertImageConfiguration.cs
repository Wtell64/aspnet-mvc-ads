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


			List<AdvertImage> imageListe = new List<AdvertImage>();
			for (int i = 1; i <= 192; i++)
			{
				int id = i;
				int advertId = (i - 1) / 3 + 1;

				imageListe.Add( new AdvertImage { Id = id, ImagePath = "http://via.placeholder.com/610x400", AdvertId = advertId });

			}


			builder.HasData(imageListe);
		}


	}
}
