using Ads.Business.Abstract;
using Ads.Business.Constants;
using Ads.Business.Dtos.Page;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
  [Area("Admin")]
	[Authorize(Roles = "Admin,Superadmin")]
	public class PageController : Controller
  {
    private readonly IPageService _pageService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IToastNotification _toastNotification;

    public PageController(IPageService pageService, UserManager<AppUser> userManager,IToastNotification toastNotification)
    {
      _pageService = pageService;
      _userManager = userManager;
      _toastNotification = toastNotification;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var pages = await _pageService.GetListAsync<Page>(includeProperties: "");
      return View(pages.Data);
    }
    [HttpGet]
    public async Task<IActionResult> Add()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(PageCRUDDto page)
    {
      try
      {
        if (ModelState.IsValid)
        {
          await _pageService.AddAsync(page);
          await _pageService.SaveAsync();
          _toastNotification.AddSuccessToastMessage(Messages.PageAdded);
          return RedirectToAction("Index");
        }
      }
      catch (Exception)
      {
        ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");
        TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
      }
      return View();
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var page = await _pageService.FindByIdAsync<Page>(id);
      var pageView = new PageCRUDDto() 
      {
        Id = id,
        Title = page.Data.Title,
        Content = page.Data.Content
      };

      return View(pageView);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(PageCRUDDto page)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _pageService.Update(page);
          await _pageService.SaveAsync();
					_toastNotification.AddWarningToastMessage(Messages.PageUpdated);
					return RedirectToAction("Index", "Page", new { area = "Admin" });
				}
      }
      catch (Exception)
      {
        ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");
        TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
      }
      return View(page);
    }
    [HttpGet]
		[Authorize(Roles ="Superadmin")]
		public async Task<IActionResult> Delete(int id)
    {
      var page = await _pageService.FindByIdAsync<PageCRUDDto>(id);
      return View(page.Data);
    }
    [HttpPost]
		[Authorize(Roles ="Superadmin")]
		public async Task<IActionResult> Delete(PageCRUDDto page)
    {
      _pageService.DeleteById(page.Id);
      await _pageService.SaveAsync();
      _toastNotification.AddErrorToastMessage(Messages.PageDeleted);
      return RedirectToAction("Index", "Page", new { area = "Admin" });
    }
  }
}
