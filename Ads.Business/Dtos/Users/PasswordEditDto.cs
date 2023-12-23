using Ads.Core.Entities.Abstract;

namespace Ads.Business.Dtos.Users;

public class PasswordEditDto : IDto
{
	public string CurrentPassword { get; set; }
	public string NewPassword { get; set; }
	public string ConfirmNewPassword { get; set; }
}
