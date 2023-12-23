using Ads.Business.Dtos.Users;
using Ads.Core.Utilities.Images;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Controllers;

public class UserController : Controller
{
	private readonly UserManager<AppUser> _userManager;
	private readonly IImageProcessor _imageProcessor;

	public UserController(UserManager<AppUser> userManager, IImageProcessor imageProcessor)
	{
		_userManager = userManager;
		_imageProcessor = imageProcessor;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		if (!User.Identity.IsAuthenticated)
			return RedirectToAction("Login", "Auth");

		var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);

		EditProfileDto editProfile = new EditProfileDto();

		editProfile.PersonalInformation = new() { FirstName = hasUser.FirstName, LastName = hasUser.LastName, Image = hasUser.ImagePath };
		editProfile.EmailEdit = new() { CurrentEmail = hasUser.Email, NewEmail = "" };
		editProfile.PasswordEdit = new() { CurrentPassword = "", NewPassword = "", ConfirmNewPassword = "" };

		return View(editProfile);
	}

	[HttpPost]
	public async Task<IActionResult> EditPersonelInformation(PersonalInformationDto personalInformation)
	{
		var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);

		if (!string.IsNullOrEmpty(personalInformation.FirstName))
			hasUser.FirstName = personalInformation.FirstName;

		if (!string.IsNullOrEmpty(personalInformation.LastName))
			hasUser.LastName = personalInformation.LastName;

		if (personalInformation.File is not null)
		{
			string fileName = await _imageProcessor.SaveImageAsync(personalInformation.File, hasUser.Id, "userProfile");
			hasUser.ImagePath = fileName;
			personalInformation.Image = fileName;
		}

		await _userManager.UpdateAsync(hasUser);

		return RedirectToAction("Index", "User");
	}

	[HttpPost]
	public async Task<IActionResult> EditPassword(PasswordEditDto passwordEdit)
	{
		var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);

		if (string.IsNullOrEmpty(passwordEdit.CurrentPassword))
			return RedirectToAction("Index", "User");

		if (string.IsNullOrEmpty(passwordEdit.NewPassword))
			return RedirectToAction("Index", "User");

		if (string.IsNullOrEmpty(passwordEdit.ConfirmNewPassword))
			return RedirectToAction("Index", "User");

		if (!await _userManager.CheckPasswordAsync(hasUser, passwordEdit.CurrentPassword))
			return RedirectToAction("Index", "User");

		await _userManager.ChangePasswordAsync(hasUser, passwordEdit.CurrentPassword, passwordEdit.ConfirmNewPassword);
		await _userManager.UpdateAsync(hasUser);

		return RedirectToAction("Index", "User");
	}

	[HttpPost]
	public async Task<IActionResult> EditEmail(EmailEditDto emailEdit)
	{
		var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);

		if (string.IsNullOrEmpty(emailEdit.CurrentEmail))
			return RedirectToAction("Index", "User");

		if (string.IsNullOrEmpty(emailEdit.NewEmail))
			return RedirectToAction("Index", "User");

		var token = await _userManager.GenerateChangeEmailTokenAsync(hasUser, emailEdit.NewEmail);

		await _userManager.ChangeEmailAsync(hasUser, emailEdit.NewEmail, token);
		await _userManager.UpdateAsync(hasUser);

		return RedirectToAction("Index", "User");
	}
}
