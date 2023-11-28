using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class City : BaseEntity, IEntity
  {
  public string Name { get; set; }

  
  public virtual ICollection<District> Districts { get; set; }

    //Relationships
    public Address Address { get; set; }
    public int AddresstId { get; set; }
  }
}
