using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public HomeController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);
				TempData["User"] = $"{hasUser.FirstName} {hasUser.LastName}";
			}

			return View();
		}
	}
}
