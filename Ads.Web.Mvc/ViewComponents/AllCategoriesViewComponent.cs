using Ads.Business.Abstract;
using Ads.Business.Dtos.Category;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.ViewComponents
{
	public class AllCategoriesViewComponent:ViewComponent
	{
	 ICategoryService _categoryService;
		
		public AllCategoriesViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
			
		}
		public IViewComponentResult Invoke()
		{
			var categories = _categoryService.GetList<Category>(includeProperties: "Subcategories");
			

			var categoryViewDto = new CategoryViewDto();
			categoryViewDto.Categories = categories.Data;
		

			return View(categoryViewDto);
		}
	}
}
