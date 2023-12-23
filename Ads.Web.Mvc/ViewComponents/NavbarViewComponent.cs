using Ads.Business.Abstract;
using Ads.Business.Dtos.Navbar;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.ViewComponents
{
	public class NavbarViewComponent : ViewComponent
	{
		IPageService _pageService;
		ICategoryService _categoryService;
		private readonly UserManager<AppUser> _userManager;

		public NavbarViewComponent(IPageService pageService, ICategoryService categoryService, UserManager<AppUser> userManager)
		{
			_pageService = pageService;
			_categoryService = categoryService;
			_userManager = userManager;
		}

		public IViewComponentResult Invoke()
		{
			var pages = _pageService.GetList<Page>();
			var categories = _categoryService.GetList<Category>();

			var navbarViewDto = new NavbarViewDto();
			navbarViewDto.Categories = categories.Data;
			navbarViewDto.Pages = pages.Data;

			return View(navbarViewDto);
		}
	}
}
