using Ads.Business.Abstract;
using Ads.Business.Dtos.Category;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.ViewComponents
{
	public class AllCategoriesViewComponent:ViewComponent
	{
	 private readonly ICategoryService _categoryService;
	 private readonly IAdvertService _advertService;


    public AllCategoriesViewComponent(ICategoryService categoryService, IAdvertService advertService)
    {
      _categoryService = categoryService;
      _advertService = advertService;
    }
    public IViewComponentResult Invoke()
		{
			var categories = _categoryService.GetList<Category>(includeProperties: "Subcategories.SubcategoryAdverts");
			

			var categoryViewDto = new CategoryViewDto();
			categoryViewDto.Categories = categories.Data;
     

      return View(categoryViewDto);
		}
	}
}
