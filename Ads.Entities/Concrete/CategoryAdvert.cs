using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class CategoryAdvert : BaseEntity
  {
  public int CategoryId { get; set; }

  public int AdvertId { get; set; }

  //Relationship
  public Advert Advert { get; set; }
  public Category Category { get; set; }
  }
}
