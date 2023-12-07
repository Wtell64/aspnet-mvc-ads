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
	public class SubcategoryAdvertConfiguration : IEntityTypeConfiguration<SubcategoryAdvert>
	{
		public void Configure(EntityTypeBuilder<SubcategoryAdvert> builder)
		{
			
			builder.HasKey(s => s.Id);

			builder.HasData(new SubcategoryAdvert { Id = 1, SubcategoryId = 1, AdvertId = 1 },
			new SubcategoryAdvert { Id = 2, SubcategoryId = 1, AdvertId = 2 },
			new SubcategoryAdvert { Id = 3, SubcategoryId = 2, AdvertId = 3 },
			new SubcategoryAdvert { Id = 4, SubcategoryId = 2, AdvertId = 4 },
			new SubcategoryAdvert { Id = 5, SubcategoryId = 3, AdvertId = 5 },
			new SubcategoryAdvert { Id = 6, SubcategoryId = 3, AdvertId = 6 },
			new SubcategoryAdvert { Id = 7, SubcategoryId = 4, AdvertId = 7 },
			new SubcategoryAdvert { Id = 8, SubcategoryId = 4, AdvertId = 8 },
			new SubcategoryAdvert { Id = 9, SubcategoryId = 5, AdvertId = 9 },
			new SubcategoryAdvert { Id = 10, SubcategoryId = 5, AdvertId = 10 },
			new SubcategoryAdvert { Id = 11, SubcategoryId = 6, AdvertId = 11 },
			new SubcategoryAdvert { Id = 12, SubcategoryId = 6, AdvertId = 12 },
			new SubcategoryAdvert { Id = 13, SubcategoryId = 7, AdvertId = 13 },
			new SubcategoryAdvert { Id = 14, SubcategoryId = 7, AdvertId = 14 },
			new SubcategoryAdvert { Id = 15, SubcategoryId = 8, AdvertId = 15 },
			new SubcategoryAdvert { Id = 16, SubcategoryId = 8, AdvertId = 16 },
			new SubcategoryAdvert { Id = 17, SubcategoryId = 9, AdvertId = 17 },
			new SubcategoryAdvert { Id = 18, SubcategoryId = 9, AdvertId = 18 },
			new SubcategoryAdvert { Id = 19, SubcategoryId = 10, AdvertId = 19 },
			new SubcategoryAdvert { Id = 20, SubcategoryId = 10, AdvertId = 20 },
			new SubcategoryAdvert { Id = 21, SubcategoryId = 11, AdvertId = 21 },
			new SubcategoryAdvert { Id = 22, SubcategoryId = 11, AdvertId = 22 },
			new SubcategoryAdvert { Id = 23, SubcategoryId = 12, AdvertId = 23 },
			new SubcategoryAdvert { Id = 24, SubcategoryId = 12, AdvertId = 24 },
			new SubcategoryAdvert { Id = 25, SubcategoryId = 13, AdvertId = 25 },
			new SubcategoryAdvert { Id = 26, SubcategoryId = 13, AdvertId = 26 },
			new SubcategoryAdvert { Id = 27, SubcategoryId = 14, AdvertId = 27 },
			new SubcategoryAdvert { Id = 28, SubcategoryId = 14, AdvertId = 28 },
			new SubcategoryAdvert { Id = 29, SubcategoryId = 15, AdvertId = 29 },
			new SubcategoryAdvert { Id = 30, SubcategoryId = 15, AdvertId = 30 },
			new SubcategoryAdvert { Id = 31, SubcategoryId = 16, AdvertId = 31 },
			new SubcategoryAdvert { Id = 32, SubcategoryId = 16, AdvertId = 32 },
			new SubcategoryAdvert { Id = 33, SubcategoryId = 17, AdvertId = 33 },
			new SubcategoryAdvert { Id = 34, SubcategoryId = 17, AdvertId = 34 },
			new SubcategoryAdvert { Id = 35, SubcategoryId = 18, AdvertId = 35 },
			new SubcategoryAdvert { Id = 36, SubcategoryId = 18, AdvertId = 36 },
			new SubcategoryAdvert { Id = 37, SubcategoryId = 19, AdvertId = 37 },
			new SubcategoryAdvert { Id = 38, SubcategoryId = 19, AdvertId = 38 },
			new SubcategoryAdvert { Id = 39, SubcategoryId = 20, AdvertId = 39 },
			new SubcategoryAdvert { Id = 40, SubcategoryId = 20, AdvertId = 40 },
			new SubcategoryAdvert { Id = 41, SubcategoryId = 21, AdvertId = 41 },
			new SubcategoryAdvert { Id = 42, SubcategoryId = 21, AdvertId = 42 },
			new SubcategoryAdvert { Id = 43, SubcategoryId = 22, AdvertId = 43 },
			new SubcategoryAdvert { Id = 44, SubcategoryId = 22, AdvertId = 44 },
			new SubcategoryAdvert { Id = 45, SubcategoryId = 23, AdvertId = 45 },
			new SubcategoryAdvert { Id = 46, SubcategoryId = 23, AdvertId = 46 },
			new SubcategoryAdvert { Id = 47, SubcategoryId = 24, AdvertId = 47 },
			new SubcategoryAdvert { Id = 48, SubcategoryId = 24, AdvertId = 48 },
			new SubcategoryAdvert { Id = 49, SubcategoryId = 25, AdvertId = 49 },
			new SubcategoryAdvert { Id = 50, SubcategoryId = 25, AdvertId = 50 },
			new SubcategoryAdvert { Id = 51, SubcategoryId = 26, AdvertId = 51 },
			new SubcategoryAdvert { Id = 52, SubcategoryId = 26, AdvertId = 52 },
			new SubcategoryAdvert { Id = 53, SubcategoryId = 27, AdvertId = 53 },
			new SubcategoryAdvert { Id = 54, SubcategoryId = 27, AdvertId = 54 },
			new SubcategoryAdvert { Id = 55, SubcategoryId = 28, AdvertId = 55 },
			new SubcategoryAdvert { Id = 56, SubcategoryId = 28, AdvertId = 56 },
			new SubcategoryAdvert { Id = 57, SubcategoryId = 29, AdvertId = 57 },
			new SubcategoryAdvert { Id = 58, SubcategoryId = 29, AdvertId = 58 },
			new SubcategoryAdvert { Id = 59, SubcategoryId = 30, AdvertId = 59 },
			new SubcategoryAdvert { Id = 60, SubcategoryId = 30, AdvertId = 60 },
			new SubcategoryAdvert { Id = 61, SubcategoryId = 31, AdvertId = 61 },
			new SubcategoryAdvert { Id = 62, SubcategoryId = 31, AdvertId = 62 },
			new SubcategoryAdvert { Id = 63, SubcategoryId = 32, AdvertId = 63 },
			new SubcategoryAdvert { Id = 64, SubcategoryId = 32, AdvertId = 64 }
			) ; 
		}
			
	}
}
