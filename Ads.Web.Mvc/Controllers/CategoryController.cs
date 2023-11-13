using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Controllers
{
  public class CategoryController : Controller
  {
    [Route("/category/category-slug")]
    public IActionResult Index(int id, int page) //id = category id, page = sayfalanma
    {
      return View();
    }
  }
}


