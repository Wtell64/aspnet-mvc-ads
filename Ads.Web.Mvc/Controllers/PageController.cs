using Ads.Business.Abstract;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Controllers
{
  public class PageController : Controller
  {
    private readonly IPageService _pageManager;

    public PageController(IPageService pageManager)
    {
      _pageManager = pageManager;
    }

    [Route("/page/{title-slug}-{id}")]
    public IActionResult Detail(int id)
    {
      var pageDetail = _pageManager.FindById<Page>(id);
      return View(pageDetail.Data);
    }
    [HttpPost]
    public IActionResult ContactUs() 
    {

      return View();
    }
  }
}
