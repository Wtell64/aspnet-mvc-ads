using Microsoft.AspNetCore.Identity;

namespace Ads.Entities.Concrete.Identity
{
	public class AppUser : IdentityUser<int>
	{

		// Adres tabloları eklenecek
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ImagePath { get; set; }

		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public bool IsActive { get; set; } = true;

		//Relationships
		public virtual ICollection<Advert> Adverts { get; set; }
		public virtual ICollection<Setting> Settings { get; set; }
		public virtual ICollection<AdvertComment> AdvertComments { get; set; }

		public Address Address { get; set; }
	}
}
