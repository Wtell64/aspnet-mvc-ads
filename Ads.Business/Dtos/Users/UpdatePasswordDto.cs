using Ads.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Ads.Business.Dtos.Users;

public class UpdatePasswordDto : IDto
{
	[Required(ErrorMessage = "Şifre alanı boş olamaz!")]
	[Display(Name = "Yeni Şifre:")]
	public string Password { get; set; }

	[Compare(nameof(Password), ErrorMessage = "Şifreler eşlemiyor!")]
	[Required(ErrorMessage = "Şifre tekrar alanı boş olamaz!")]
	[Display(Name = "Yeni Şifre Tekrar:")]
	public string PasswordConfirm { get; set; }
}
