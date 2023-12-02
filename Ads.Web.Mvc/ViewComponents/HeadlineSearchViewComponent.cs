using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.ViewComponents
{
	public class HeadlineSearchViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
