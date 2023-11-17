using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class AdvertImage : BaseEntity
  {
  public string ImagePath { get; set; }
  //Relationship
  public int AdvertId { get; set; }
  public Advert Advert { get; set; }


  }
}
