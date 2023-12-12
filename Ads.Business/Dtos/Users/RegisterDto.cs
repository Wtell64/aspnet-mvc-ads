using Ads.Business.Extentions;
using Ads.Core.Entities.Abstract;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ads.Business.Dtos.Users
{
	public class RegisterDto : IDto
	{
		[Required(ErrorMessage = "Ad alanı boş olamaz!")]
		[Display(Name = "Adın:")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Soyad alanı boş olamaz!")]
		[Display(Name = "Soyadın:")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "E-mail alanı boş olamaz!")]
		[EmailAddress(ErrorMessage = "E-mail formatı yanlış!")]
		[Display(Name = "E-mail:")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre alanı boş olamaz!")]
		[Display(Name = "Şifre:")]
		public string Password { get; set; }

		[Compare(nameof(Password), ErrorMessage = "Şifreler eşlemiyor!")]
		[Required(ErrorMessage = "Şifre tekrar alanı boş olamaz!")]
		[Display(Name = "Şifre Tekrar:")]
		public string PasswordConfirm { get; set; }

		[MustBeTrue(ErrorMessage = "Şartlar & Koşullar alanı boş olamaz!")]
		public bool TermAndCondition { get; set; }

		[Range(1, 99, ErrorMessage = "Bir şehir seçilmelidir.")]
		public int CityId { get; set; }

		[Range(1, 99, ErrorMessage = "Bir ilçe seçilmelidir.")]
		public int DistrictId { get; set; }

		[Required(ErrorMessage = "Detaylı adres alanı boş olamaz!")]
		public string DetailedAddress { get; set; }

		public Address? Address { get; set; }



		public IEnumerable<SelectListItem>? Cities { get; set; }
		public IEnumerable<SelectListItem>? Districts { get; set; }
	}
}