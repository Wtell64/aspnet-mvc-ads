using Ads.Business.Abstract;
using Ads.Business.Dtos.Page;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class PageController : Controller
  {
    private readonly IPageService _pageService;
    private readonly UserManager<AppUser> _userManager;

    public PageController(IPageService pageService, UserManager<AppUser> userManager)
    {
      _pageService = pageService;
      _userManager = userManager;
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
          TempData["SuccessMessage"] = "Sayfa başarıyla keydedildi.";
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
          TempData["SuccessMessage"] = "Sayfa başarıyla güncellendi.";
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
    public async Task<IActionResult> Delete(int id)
    {
      var page = await _pageService.FindByIdAsync<PageCRUDDto>(id);
      return View(page.Data);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(PageCRUDDto page)
    {
      _pageService.DeleteById(page.Id);
      await _pageService.SaveAsync();
      return RedirectToAction("Index", "Page", new { area = "Admin" });
    }
  }
}
