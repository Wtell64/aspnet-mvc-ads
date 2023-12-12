using Ads.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Ads.Business.Dtos.Users
{
	public class LoginDto : IDto
	{
		[Required(ErrorMessage = "E-mail alanı boş olamaz!")]
		[EmailAddress(ErrorMessage = "E-mail formatı yanlış!")]
		[Display(Name = "E-mail:")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre alanı boş olamaz!")]
		[Display(Name = "Şifre:")]
		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
