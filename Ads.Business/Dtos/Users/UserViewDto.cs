using Ads.Core.Entities.Abstract;

namespace Ads.Business.Dtos.Users
{
	public class UserViewDto : IDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		public string FullName => $"{FirstName.Substring(0, 1).ToUpper()}{FirstName.Substring(1).ToLower()} {LastName.ToUpper()}";
	}
}
