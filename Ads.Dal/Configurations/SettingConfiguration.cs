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
    }
  }
}
