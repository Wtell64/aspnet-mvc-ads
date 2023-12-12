using Ads.Core.Entities.Abstract;

namespace Ads.Business.Dtos.Users;

public class EmailSenderDto : IDto
{
	public string Host { get; set; }
	public string Password { get; set; }
	public string Email { get; set; }
}
