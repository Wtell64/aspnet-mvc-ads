using Ads.Business.Dtos.Category;
using Ads.Core.Entities.Abstract;
using Ads.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Subcategory
{
	public class SubcategoryViewDto : IDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public int CategoryId { get; set; }
    public CategoryViewDto Category { get; set; }
    public virtual ICollection<SubcategoryAdvert> SubcategoryAdverts { get; set; }

  }
}
