using Ads.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Dal.Configurations
{
  public class CategoryConfiguration : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(100)");
      builder.Property(c => c.Description).IsRequired().HasColumnType("nvarchar(200)");


      //builder
      //      .HasMany(c => c.ProductCategory)
      //      .WithOne(pc => pc.Category)
      //      .HasForeignKey(pc => pc.CategoryId)
      //      .OnDelete(DeleteBehavior.Restrict);

      builder.HasData(
        new Category { Id = 1, Name = "Gazlı içeçek", Description= "Deneme" }

      );
    }
  }
}
