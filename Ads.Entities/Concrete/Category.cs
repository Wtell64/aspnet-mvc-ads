using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class Category : BaseEntity
  {
   public string Name { get; set; }
   public string Description { get; set; }

   public virtual ICollection<CategoryAdvert> CategoryAdverts { get; set; }
  }
}
