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
      builder.Property(c => c.DarkModeOnOff).IsRequired().HasColumnType("nvarchar(5)");
      builder.Property(c=>c.DarkMode).HasDefaultValue(false).HasColumnType("bit");

      builder
        .HasOne(s => s.User)
        .WithMany(s => s.Settings)
        .HasForeignKey(s => s.UserId)
        .OnDelete(DeleteBehavior.Restrict);

      builder.HasData(
        new Setting { Id = 1, UserId = 1 , Name = "MaxPostPerPage", Value = "50",DarkModeOnOff = "ON",DarkMode=true },
        new Setting { Id = 2, UserId = 2, Name = "MaxPostPerPage", Value = "20",DarkModeOnOff="OFF",DarkMode=false },
        new Setting { Id = 3, UserId = 3, Name = "MaxPostPerPage", Value = "10",DarkModeOnOff="ON",DarkMode=true }
        );

    }
  }
}
