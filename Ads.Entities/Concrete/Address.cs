using Ads.Core.Entities.Abstract;
using Ads.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class Address : BaseEntity, IEntity
  {
  

  public string PostCode { get; set; }

  public string Country { get; set; }

  public string DetailedAddress { get; set; }

  //Relationship
  public virtual ICollection<City> Cities { get; set; }

  public AppUser User { get; set; }
  public int UserId { get; set; }
  }
  
}
