using Ads.Business.Abstract;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.ViewComponents
{
	public class PopularCategoriesViewComponent : ViewComponent
	{

		ICategoryService _categoryService;
		public PopularCategoriesViewComponent(ICategoryService categoryService)
		{

			_categoryService = categoryService;
		}

		public IViewComponentResult Invoke()
		{
			var categories = _categoryService.GetList<Category>(null, null, "SubcategoryAdverts.Advert");

			//var popularCategories = categories.Data
			//			.OrderByDescending(category => category.SubcategoryAdverts.Sum(advert => advert.Advert.ClickCount))
			//			.Take(5)
			//			.ToList();
			//popularCategories return
			return View();
		}
	}
}
