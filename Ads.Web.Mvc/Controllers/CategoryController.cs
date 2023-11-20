using Ads.Business.Abstract;
using Ads.Business.Dtos.Category;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Controllers
{
  public class CategoryController : Controller
  {
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }
    [Route("/category/category-slug")]
    public IActionResult Index(int id, int page) //id = category id, page = sayfalanma
    {
      return View();
    }


  }
}


