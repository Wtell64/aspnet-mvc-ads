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
  public class AdvertCommentConfiguration : IEntityTypeConfiguration<AdvertComment>
  {
    public void Configure(EntityTypeBuilder<AdvertComment> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(a => a.Comment).IsRequired().HasColumnType("text");

      builder
      .HasOne(ac => ac.Advert)
      .WithMany(a => a.AdvertComments)
      .HasForeignKey(ac => ac.AdvertId)
      .OnDelete(DeleteBehavior.Restrict);

      builder
.HasOne(ac => ac.User)
.WithMany(u => u.AdvertComments)
.HasForeignKey(ac => ac.UserId)
.OnDelete(DeleteBehavior.Restrict);

      builder.HasData(
    new AdvertComment { Id = 1, Comment = "Great product, highly recommended!", AdvertId = 1, UserId = 3 },
    new AdvertComment { Id = 2, Comment = "Interesting features. I might consider buying it.", AdvertId = 2, UserId = 3 },
    new AdvertComment { Id = 3, Comment = "Not sure about the price. Is there any discount?", AdvertId = 3, UserId = 3 },
    new AdvertComment { Id = 4, Comment = "Love the design! Where can I find more details?", AdvertId = 4, UserId = 3 },
    new AdvertComment { Id = 5, Comment = "This is exactly what I've been looking for!", AdvertId = 5, UserId = 3 },
    new AdvertComment { Id = 6, Comment = "Any warranty information available?", AdvertId = 6, UserId = 3 },
    new AdvertComment { Id = 7, Comment = "I have a similar product, and it's fantastic!", AdvertId = 7, UserId = 3 },
    new AdvertComment { Id = 8, Comment = "Can you provide more details about the specifications?", AdvertId = 8, UserId = 3 },
    new AdvertComment { Id = 9, Comment = "Do you ship internationally?", AdvertId = 9, UserId = 3 },
    new AdvertComment { Id = 10, Comment = "Impressive! I'll share this with my friends.", AdvertId = 10, UserId = 3 },
    new AdvertComment { Id = 11, Comment = "How long is the battery life?", AdvertId = 1, UserId = 3 },
    new AdvertComment { Id = 12, Comment = "Is there a demo video available?", AdvertId = 2, UserId = 3 },
    new AdvertComment { Id = 13, Comment = "I'd like to see more pictures of the product.", AdvertId = 3, UserId = 3 },
    new AdvertComment { Id = 14, Comment = "What colors are available?", AdvertId = 4, UserId = 3 },
    new AdvertComment { Id = 15, Comment = "Can you offer a discount for bulk orders?", AdvertId = 5, UserId = 3 }
);
    }


  }
}
