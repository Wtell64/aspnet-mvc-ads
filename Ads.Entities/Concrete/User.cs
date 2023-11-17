using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class User : BaseEntity
  {
  public string Email { get; set; }
  public string Password { get; set; }
  public string Name { get; set; }
  public string Address { get; set; }
  public string Phone { get; set; }


  //Relationships
  public virtual ICollection<Advert> Adverts{ get; set; }
  public virtual ICollection<Setting> Settings { get; set; }
  public virtual ICollection<AdvertComment> AdvertComments { get; set; }
  }
}
