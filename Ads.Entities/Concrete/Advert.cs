using Ads.Entities.Concrete.Enums;
using Ads.Entities.Concrete.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ads.Entities.Concrete
{
	public class Advert : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		
		public int Price { get; set; }

		public int ClickCount { get; set; }
		


		public AdvertConditionEnum ConditionEnum { get; set; }

		//Relationship
		public virtual ICollection<SubcategoryAdvert> SubcategoryAdverts { get; set; }
		public virtual ICollection<AdvertImage> AdvertImages { get; set; }

		public virtual ICollection<AdvertComment> AdvertComments { get; set; }
		public AppUser User { get; set; }
		public int UserId { get; set; }
	}
}
