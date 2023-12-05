using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Controllers
{
  public class PageController : Controller
  {
    [Route("/page/{title-slug}-{id}")]
    public IActionResult Detail(int id)
    {
      return View();
    }
  }
}
