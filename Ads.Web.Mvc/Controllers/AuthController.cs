using Ads.Business.Dtos.Users;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Controllers
{
	public class AuthController : Controller
	{

		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Login(string redirectUrl)
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(UserLoginDto userLoginDto)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
				if (user is not null)
				{
					var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
					if (result.Succeeded)
						return RedirectToAction("Index", "Home", new { Area = "Admin" });
					else
					{
						ModelState.AddModelError("", "E-Posta adresiniz veya şifreniz yanlış!");
						return View();
					}
				}
				else
				{
					ModelState.AddModelError("", "E-Posta adresiniz veya şifreniz yanlış!");
					return View();
				}
			}
			return View();
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home", new { Area = "" });
		}


		public IActionResult ForgotPassword()
		{
			return View();
		}
	}
}
