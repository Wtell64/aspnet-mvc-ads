using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Areas.Admin.ViewComponents
{
	public class AdminNameViewComponent : ViewComponent
	{

		private readonly UserManager<AppUser> _userManager;

		public AdminNameViewComponent(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var userName = "";
			if (User.Identity.IsAuthenticated)
			{
				var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);
				userName = $"{hasUser.FirstName} {hasUser.LastName}";
			}
			return View("Default", userName);
		}
	}
}
