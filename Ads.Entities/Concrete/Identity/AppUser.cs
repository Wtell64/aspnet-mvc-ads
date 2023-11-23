using Microsoft.AspNetCore.Identity;

namespace Ads.Entities.Concrete.Identity
{
	public class AppUser : IdentityUser<int>
	{

		// Adres tabloları eklenecek
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? Address { get; set; }

		//Relationships
		public virtual ICollection<Advert> Adverts { get; set; }
		public virtual ICollection<Setting> Settings { get; set; }
		public virtual ICollection<AdvertComment> AdvertComments { get; set; }
	}
}
