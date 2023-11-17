using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class AdvertComment : BaseEntity
  {
  public string Comment { get; set; }

  //Relationships

  public int AdvertId { get; set; }
  public Advert Advert { get; set; }

  public int UserId { get; set; }
  public User User { get; set; }



  }
}
