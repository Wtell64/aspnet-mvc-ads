using Ads.Entities.Concrete.Identity;

namespace Ads.Entities.Concrete
{
	public class Setting : BaseEntity
	{
		public string Name { get; set; }
		public string Value { get; set; }

		//Relationships

		public int UserId { get; set; }
		public AppUser User { get; set; }
	}
}
