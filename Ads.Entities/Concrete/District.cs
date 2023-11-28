using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class District : BaseEntity, IEntity
  {
  public string Name { get; set; }
    //Relationships
    public City City { get; set; }
    public int CityId { get; set; }
  }
}
