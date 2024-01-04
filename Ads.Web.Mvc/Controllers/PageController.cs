using Ads.Business.Abstract;
using Ads.Business.Abstract.Identity;
using Ads.Business.Constants;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Ads.Web.Mvc.Controllers
{

  public class PageController : Controller
  {
    private readonly IPageService _pageManager;
    private readonly IEmailService _emailService;
    private readonly IToastNotification _toastNotification;
    public PageController(IPageService pageManager, IEmailService emailService, IToastNotification toastNotification)
    {
      _pageManager = pageManager;
      _emailService = emailService;
      _toastNotification = toastNotification;
    }

    [Route("/page/{titleSlug}-{id}")]
    public IActionResult Detail(int id)
    {
      var pageDetail = _pageManager.FindById<Page>(id);
      return View(pageDetail.Data);
    }
    [HttpPost]
    public async Task<IActionResult> SubmitForm(string message, string userName, string userEmail)
    {
      await _emailService.RecieveEmailAsync(message, userName, userEmail);
      _toastNotification.AddSuccessToastMessage(Messages.MessageRecieved);
      return RedirectToAction("Detail", "Page", new { id = 2, titleSlug = "Bize Ulaşın" });
    }
  }
}
