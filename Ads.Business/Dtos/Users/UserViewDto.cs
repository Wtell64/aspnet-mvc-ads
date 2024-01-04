using Ads.Core.Entities.Abstract;

namespace Ads.Business.Dtos.Users
{
	public class UserViewDto : IDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }
		public DateTime CreatedDate { get; set; }

		public string FullName => $"{FirstName} {LastName}";
	}
}
