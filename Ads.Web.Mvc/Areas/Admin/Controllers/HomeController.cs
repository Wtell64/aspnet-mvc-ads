using Ads.Business.Dtos.Users;
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
		public IActionResult Index() => View();

		[HttpGet]
		public async Task<IActionResult> UserList()
		{
			var userList = await _userManager.GetUsersInRoleAsync("user");

			var userVieModelList = userList.Select(uvd => new UserViewDto()
			{
				Id = uvd.Id,
				FirstName = uvd.FirstName,
				LastName = uvd.LastName,
				Email = uvd.Email,
			}).ToList();

			return View(userVieModelList);
		}

	}
}
