using Ads.Core.Entities.Abstract;

namespace Ads.Business.Dtos.Users;

public class EditProfileDto : IDto
{
	public PasswordEditDto PasswordEdit { get; set; }
	public PersonalInformationDto PersonalInformation { get; set; }
	public EmailEditDto EmailEdit { get; set; }

}
