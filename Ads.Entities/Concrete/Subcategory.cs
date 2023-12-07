using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
	public class Subcategory : BaseEntity, IEntity
	{
		public string Name { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public virtual ICollection<SubcategoryAdvert> SubcategoryAdverts { get; set; }
	}
}
