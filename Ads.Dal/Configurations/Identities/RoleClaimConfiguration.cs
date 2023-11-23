using Ads.Entities.Concrete.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations.Identities
{
	public class RoleClaimConfiguration : IEntityTypeConfiguration<AppRoleClaim>
	{
		public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
		{
			// Primary key
			builder.HasKey(rc => rc.Id);

			// Maps to the AspNetRoleClaims table
			builder.ToTable("AspNetRoleClaims");
		}
	}
}
