using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Subcategory
{
	public class SubcategoryViewDto : IDto
	{
		public string Name { get; set; }
		public int CategoryId { get; set; }

	}
}
