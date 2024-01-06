using Ads.Business.Abstract;
using Ads.Business.Abstract.Identity;
using Ads.Business.Constants;
using Ads.Business.Dtos.Users;
using Ads.Business.Extentions;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;


namespace Ads.Web.Mvc.Controllers;

public class AuthController : Controller
{

	private readonly UserManager<AppUser> _userManager;
	private readonly SignInManager<AppUser> _signInManager;
	private readonly IEmailService _emailService;
	private readonly ICityService _cityService;
	private readonly IDistrictService _districtService;
	private readonly IAddressService _addressService;
	private readonly IToastNotification _toastNotification;


	public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICityService cityService, IDistrictService districtService, IAddressService addressService, IEmailService emailService, IToastNotification toastNotification)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_cityService = cityService;
		_districtService = districtService;
		_addressService = addressService;
		_emailService = emailService;
		_toastNotification = toastNotification;
	}

	[HttpGet]
	public IActionResult Register()
	{
		var cities = _cityService.GetList<City>(orderBy: q => q.OrderBy(x => x.Name));
		var districts = _districtService.GetList<District>(orderBy: q => q.OrderBy(x => x.Name));

		ViewBag.City = new SelectList(cities.Data, "Id", "Name");
		ViewBag.Districts = new SelectList(districts.Data, "Id", "Name");

		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(RegisterDto request)
	{
		if (!ModelState.IsValid)
		{
			var cities = _cityService.GetList<City>(orderBy: q => q.OrderBy(x => x.Name));
			var districts = _districtService.GetList<District>(orderBy: q => q.OrderBy(x => x.Name));

			ViewBag.City = new SelectList(cities.Data, "Id", "Name");
			ViewBag.Districts = new SelectList(districts.Data, "Id", "Name");
			return View(request);
		}

		var newUser = new AppUser()
		{
			UserName = request.Email,
			NormalizedUserName = request.Email.ToUpper().Replace("İ", "I"),
			Email = request.Email,
			NormalizedEmail = request.Email.ToUpper().Replace("İ", "I"),
			FirstName = request.FirstName,
			LastName = request.LastName,
			SecurityStamp = Guid.NewGuid().ToString(),
			ImagePath = "deneme",
			Address = new Address
			{
				PostCode = _addressService.FindById<Address>(request.CityId).Data.PostCode,
				Country = "Türkiye",
				City = _cityService.FindById<City>(request.CityId).Data,
				District = _districtService.FindById<District>(request.DistrictId).Data,
				DetailedAddress = request.DetailedAddress,
				UserId = _userManager.Users.Count() + 1,
				CityId = request.CityId,
				DistrictId = request.DistrictId,
			},

		};
		var identityResult = await _userManager.CreateAsync(newUser, request.PasswordConfirm);

		await _userManager.AddToRoleAsync(newUser, "user");

		if (identityResult.Succeeded)
		{
			_toastNotification.AddSuccessToastMessage(Messages.RegisterSuccessMessage);
			var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);


			var approvalEmailLink = Url.Action(nameof(ConfirmEmail), "Auth", new { newUser.Id, token });

			await _emailService.SendEmailAsync(approvalEmailLink, newUser.Email, "Onay Mail Linki", "Mail adresinizi onaylamak");


			return RedirectToAction(nameof(Login), "Auth");
		}

		ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());

		return View();
	}

	[HttpGet]
	public JsonResult GetDistrictsByCityId(int cityId)
	{
		return Json(_districtService.GetList<District>(d => d.CityId.Equals(cityId)).Data);
	}

	[HttpGet]
	public IActionResult Login() => View();

	[HttpPost]
	public async Task<IActionResult> Login(LoginDto userLoginDto, string? redirectUrl = null)
	{
		if (!ModelState.IsValid)
			return View(userLoginDto);

		redirectUrl = redirectUrl ?? Url.Action(nameof(HomeController.Index), "Home");

		var hasUser = await _userManager.FindByEmailAsync(userLoginDto.Email);

		if (hasUser is null)
		{
			ModelState.AddModelError(string.Empty, "E-mail veya şifre yanlış!");
			return View();
		}

		await _signInManager.SignOutAsync();

		if (!await _userManager.IsEmailConfirmedAsync(hasUser))
		{
			ModelState.AddModelErrorList(new List<string> { "Hesabınızı onaylayın!" });
			return View(userLoginDto);
		}


		var loginResult = await _signInManager.PasswordSignInAsync(user: hasUser, password: userLoginDto.Password, isPersistent: userLoginDto.RememberMe, lockoutOnFailure: true);
		if (loginResult.Succeeded)
		{
			TempData["User"] = $"{hasUser.FirstName} {hasUser.LastName}";

			await _userManager.ResetAccessFailedCountAsync(hasUser);
			await _userManager.SetLockoutEndDateAsync(hasUser, null);

			if (await _userManager.IsInRoleAsync(hasUser, "Admin") || await _userManager.IsInRoleAsync(hasUser, "SuperAdmin"))
				return RedirectToAction("Index", "Home", new { area = "Admin" });

			return Redirect(redirectUrl);
		}

		if (loginResult.IsLockedOut)
		{
			ModelState.AddModelErrorList(new List<string> { "3'den fazla yanlış girdiğiniz için 5 dakika boyunca giriş yapamazsınız!" });
			return View();
		}
		ModelState.AddModelErrorList(new List<string> { "Email veya şifre yanlış!", $"{3 - (await _userManager.GetAccessFailedCountAsync(hasUser))} hakkınız kaldı... " });
		return View();
	}

	[HttpGet]
	public async Task<IActionResult> Logout()
	{
		await _signInManager.SignOutAsync();
		return RedirectToAction("Index", "Home", new { Area = "" });
	}

	[HttpGet]
	public IActionResult ForgotPassword() => View();

	[HttpPost]
	public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
	{
		if (!ModelState.IsValid)
			return View();

		var hasUser = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);

		if (hasUser is null)
		{
			ModelState.AddModelError(string.Empty, "Bu mail adresine ait kullanıcı bulunamamıştır!");
			return View();
		}

		string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);

		var passwordResetLink = Url.Action(nameof(UpdatePassword), "Auth", new { userId = hasUser.Id, Token = passwordResetToken });

		await _emailService.SendEmailAsync(passwordResetLink, forgotPasswordDto.Email, "Şifre Yenileme", "Şifrenizi yenilemek");

		_toastNotification.AddSuccessToastMessage(Messages.SuccessResetPassword);

		return RedirectToAction(nameof(ForgotPassword), "Auth");

	}

	[HttpGet]
	public ActionResult UpdatePassword(string userId, string token)
	{
		TempData["userId"] = userId;
		TempData["token"] = token;

		return View();
	}

	[HttpPost]
	public async Task<IActionResult> UpdatePassword(UpdatePasswordDto updatePasswordDto)
	{

		if (!ModelState.IsValid)
			return View();

		var userId = TempData["userId"];
		var token = TempData["token"];

		if (userId is null || token is null) { _toastNotification.AddErrorToastMessage(Messages.CheckTokenOrMailAdress); }

		var hasUser = await _userManager.FindByIdAsync(userId.ToString()!);

		if (hasUser is null)
		{
			ModelState.AddModelError(string.Empty, "Kullanıcı bulunamamıştır!");
			return View();
		}

		var result = await _userManager.ResetPasswordAsync(hasUser, token.ToString()!, updatePasswordDto.Password);

		if (result.Succeeded)
			_toastNotification.AddWarningToastMessage(Messages.PasswordUpdated);
		else
			ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());

		return View();
	}

	[HttpGet]
	public IActionResult TermCondition() => View();

	[HttpGet]
	public async Task<IActionResult> ConfirmEmail(int id, string token)
	{

		if (token is null)
		{
			_toastNotification.AddInfoToastMessage(Messages.CheckTokenOrMailAdress);
			return View();
		}

		var hasUser = await _userManager.FindByIdAsync(id.ToString());
		if (hasUser is not null)
		{
			var result = await _userManager.ConfirmEmailAsync(hasUser, token);

			if (result.Succeeded)
			{
				_toastNotification.AddSuccessToastMessage(Messages.AccountApproved);
				return RedirectToAction(nameof(Login), "Auth");
			}
		}

		_toastNotification.AddErrorToastMessage(Messages.UserNotFound);
		return View();
	}
	public async Task<IActionResult> AccessDenied()
	{
		return View();
	}

}
