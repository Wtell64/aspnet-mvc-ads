using Ads.Entities.Concrete.Identity;

namespace Ads.Entities.Concrete
{
	public class Advert : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		
		public int Price { get; set; }


		//Relationship
		public virtual ICollection<CategoryAdvert> CategoryAdverts { get; set; }
		public virtual ICollection<AdvertImage> AdvertImages { get; set; }

		public virtual ICollection<AdvertComment> AdvertComments { get; set; }
		public AppUser User { get; set; }
		public int UserId { get; set; }
	}
}
