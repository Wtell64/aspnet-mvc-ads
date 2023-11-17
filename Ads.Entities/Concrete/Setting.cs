using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class Setting : BaseEntity
  {
  public string Name { get; set; }
  public string Value { get; set; }

  //Relationships

  public int UserId { get; set; }
  public User User { get; set; }
  }
}
