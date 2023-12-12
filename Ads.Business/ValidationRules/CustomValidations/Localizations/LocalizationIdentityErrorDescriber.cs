using Microsoft.AspNetCore.Identity;

namespace Ads.Business.ValidationRules.CustomValidations.Localizations;

public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
{
	public override IdentityError DuplicateEmail(string email) => new IdentityError { Code = "DublicateEmail", Description = $"Bu {email} adresi daha önceden alınmıştır!" };

	public override IdentityError PasswordTooShort(int lenght) => new IdentityError { Code = "PasswordTooShort", Description = "Şifre en az 6 karakterli olmalıdır." };
}
