using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class Advert : BaseEntity
  {
  public string Title { get; set; }
  public string Description { get; set; }


  //Relationship
  public virtual ICollection<CategoryAdvert> CategoryAdverts { get; set; }
  public virtual ICollection<AdvertImage> AdvertImages { get; set; }

  public virtual ICollection <AdvertComment> AdvertComments { get; set; }
  public User User { get; set; }
  public int UserId { get; set; }
  }
}
