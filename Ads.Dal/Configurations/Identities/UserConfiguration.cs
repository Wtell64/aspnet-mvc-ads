using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations.Identities
{
  public class UserConfiguration : IEntityTypeConfiguration<AppUser>
  {
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
      builder.HasKey(u => u.Id);

      // Indexes for "normalized" username and email, to allow efficient lookups
      builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
      builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

      // Maps to the AspNetUsers table
      builder.ToTable("AspNetUsers");

      // A concurrency token for use with the optimistic concurrency checking
      builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

      // Limit the size of columns to use efficient database types
      builder.Property(u => u.UserName).HasMaxLength(100);
      builder.Property(u => u.PhoneNumber).HasColumnType("varchar(20)");
      builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
      builder.Property(u => u.Email).HasColumnType("varchar(200)");
      builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

      // The relationships between User and other entity types
      // Note that these relationships are configured with no navigation properties

      // Each User can have many UserClaims
      builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

      // Each User can have many UserLogins
      builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

      // Each User can have many UserTokens
      builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

      // Each User can have many entries in the UserRole join table
      builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

      var superadmin = new AppUser
      {
        Id = 1,
        UserName = "superadmin@gmail.com",
        NormalizedUserName = "SUPERADMIN@GMAIL.COM",
        Email = "superadmin@gmail.com",
        NormalizedEmail = "SUPERADMIN@GMAIL.COM",
        PhoneNumber = "+000000000",
        FirstName = "SuperAdmin",
        LastName = "SuperAdmin",
        PhoneNumberConfirmed = true,
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        ImagePath = "deneme"
      };
      superadmin.PasswordHash = CreatePasswordHash(superadmin, "123456");

      var admin = new AppUser
      {
        Id = 2,
        UserName = "admin@gmail.com",
        NormalizedUserName = "ADMIN@GMAIL.COM",
        Email = "admin@gmail.com",
        NormalizedEmail = "ADMIN@GMAIL.COM",
        PhoneNumber = "+000000000",
        FirstName = "Admin",
        LastName = "Admin",
        PhoneNumberConfirmed = false,
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        ImagePath = "deneme"
      };
      admin.PasswordHash = CreatePasswordHash(admin, "123456");

      var aras = new AppUser
      {
        Id = 3,
        UserName = "user1@gmail.com",
        NormalizedUserName = "USER1@GMAIL.COM",
        Email = "user1@gmail.com",
        NormalizedEmail = "USER1@GMAIL.COM",
        PhoneNumber = "+000000000",
        FirstName = "Aras",
        LastName = "Menteşe",
        PhoneNumberConfirmed = false,
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        ImagePath = "deneme"
      };
      aras.PasswordHash = CreatePasswordHash(aras, "123456");

      var elif = new AppUser
      {
        Id = 4,
        UserName = "user2@gmail.com",
        NormalizedUserName = "USER2@GMAIL.COM",
        Email = "user2@gmail.com",
        NormalizedEmail = "USER2@GMAIL.COM",
        PhoneNumber = "+000000000",
        FirstName = "Elif",
        LastName = "Sakçı Tuncer",
        PhoneNumberConfirmed = false,
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        ImagePath = "deneme"
      };
      elif.PasswordHash = CreatePasswordHash(elif, "123456");

      var ismail = new AppUser
      {
        Id = 5,
        UserName = "user3@gmail.com",
        NormalizedUserName = "USER3@GMAIL.COM",
        Email = "user3@gmail.com",
        NormalizedEmail = "USER3@GMAIL.COM",
        PhoneNumber = "+000000000",
        FirstName = "İsmail",
        LastName = "Yücer",
        PhoneNumberConfirmed = false,
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        ImagePath = "deneme"
      };
      ismail.PasswordHash = CreatePasswordHash(ismail, "123456");

      var muratcan = new AppUser
      {
        Id = 6,
        UserName = "user4@gmail.com",
        NormalizedUserName = "USER4@GMAIL.COM",
        Email = "user4@gmail.com",
        NormalizedEmail = "USER4@GMAIL.COM",
        PhoneNumber = "+000000000",
        FirstName = "Muratcan",
        LastName = "Agıç",
        PhoneNumberConfirmed = false,
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        ImagePath = "deneme"
      };
      muratcan.PasswordHash = CreatePasswordHash(muratcan, "123456");

      var ridvan = new AppUser
      {
        Id = 7,
        UserName = "user5@gmail.com",
        NormalizedUserName = "USER5@GMAIL.COM",
        Email = "user5@gmail.com",
        NormalizedEmail = "USER5@GMAIL.COM",
        PhoneNumber = "+000000000",
        FirstName = "Rıdvan",
        LastName = "Kesken",
        PhoneNumberConfirmed = false,
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        ImagePath = "deneme"
      };
      ridvan.PasswordHash = CreatePasswordHash(ridvan, "123456");

      builder.HasData(superadmin, admin, aras, elif, ismail, muratcan, ridvan);

    }
    private string CreatePasswordHash(AppUser user, string password)
    {
      var passwordHasher = new PasswordHasher<AppUser>();
      return passwordHasher.HashPassword(user, password);
    }
  }
}
