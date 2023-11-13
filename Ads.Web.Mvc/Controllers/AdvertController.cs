using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Controllers
{
 
  public class AdvertController : Controller
  {
    
    public IActionResult Search(string query, int page)
    {
      return View();
    }
    [Route("/advert/title-slug")]
    public IActionResult Detail(int id)
    {
      return View();
    }
  }
}
