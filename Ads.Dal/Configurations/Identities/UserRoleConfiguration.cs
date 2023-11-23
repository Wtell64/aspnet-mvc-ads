using Ads.Entities.Concrete.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations.Identities
{
	public class UserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
	{
		public void Configure(EntityTypeBuilder<AppUserRole> builder)
		{
			// Primary key
			builder.HasKey(r => new { r.UserId, r.RoleId });

			// Maps to the AspNetUserRoles table
			builder.ToTable("AspNetUserRoles");

			builder.HasData(new AppUserRole
			{
				UserId = 1,
				RoleId = 1
			},
			new AppUserRole
			{
				UserId = 2,
				RoleId = 2
			});
		}
	}
}