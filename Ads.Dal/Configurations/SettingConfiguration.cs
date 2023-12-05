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
      builder.Property(c=>c.DarkMode).HasDefaultValue(false).HasColumnType("boolean");

      builder
        .HasOne(s => s.User)
        .WithMany(s => s.Settings)
        .HasForeignKey(s => s.UserId)
        .OnDelete(DeleteBehavior.Restrict);

      builder.HasData(
        new Setting { Id = 1, Name = "MaxPostPerPage", Value = "50", UserId = 1 },
        new Setting { Id = 2,Name = "DarkMode",Value = "ON", DarkMode = true,UserId = 1},
        new Setting { Id = 1, Name = "MaxPostPerPage", Value = "20", UserId = 2 },
        new Setting { Id = 2, Name = "DarkMode", Value = "OFF", DarkMode = false, UserId = 2 },
        new Setting { Id = 1, Name = "MaxPostPerPage", Value = "10", UserId = 3 },
        new Setting { Id = 2, Name = "DarkMode", Value = "ON", DarkMode = true, UserId = 3 }
        );

    }
  }
}
