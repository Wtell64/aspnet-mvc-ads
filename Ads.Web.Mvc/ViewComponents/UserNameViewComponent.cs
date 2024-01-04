using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.ViewComponents
{
	public class UserNameViewComponent : ViewComponent
	{

		private readonly UserManager<AppUser> _userManager;

		public UserNameViewComponent(UserManager<AppUser> userManager)
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
