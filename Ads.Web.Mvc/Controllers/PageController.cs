using Ads.Business.Abstract;
using Ads.Business.Abstract.Identity;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Controllers
{

  public class PageController : Controller
  {
    private readonly IPageService _pageManager;
    private readonly IEmailService _emailService;

    public PageController(IPageService pageManager, IEmailService emailService)
    {
      _pageManager = pageManager;
      _emailService = emailService;
    }

    [Route("/page/{title-slug}-{id}")]
    public IActionResult Detail(int id)
    {
      var pageDetail = _pageManager.FindById<Page>(id);
      return View(pageDetail.Data);
    }
    [HttpPost]
    public async Task<IActionResult> SubmitForm(string message, string userName, string userEmail)
    {
      await _emailService.RecieveEmailAsync(message, userName, userEmail);
      return RedirectToAction("Detail", "Page", new { id = 2 });
    }
  }
}
