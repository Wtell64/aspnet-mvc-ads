using Ads.Entities.Concrete.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations.Identities
{
	public class UserClaimConfiguration : IEntityTypeConfiguration<AppUserClaim>
	{
		public void Configure(EntityTypeBuilder<AppUserClaim> builder)
		{
			// Primary key
			builder.HasKey(uc => uc.Id);

			// Maps to the AspNetUserClaims table
			builder.ToTable("AspNetUserClaims");
		}
	}
}
