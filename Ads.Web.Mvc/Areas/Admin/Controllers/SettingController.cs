using Ads.Business.Abstract;
using Ads.Business.Constants;
using Ads.Business.Dtos.Setting;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using NToastNotify;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
  [Area("Admin")]
  [Authorize(Roles = "Admin,Superadmin")]
  public class SettingController : Controller
  {
    private readonly ISettingService _settingService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IToastNotification _toastNotification;

		public SettingController(ISettingService settingService, UserManager<AppUser> userManager, IToastNotification toastNotification)
		{
			_settingService = settingService;
			_userManager = userManager;
			_toastNotification = toastNotification;
		}

		[HttpGet]
    public async Task<IActionResult> Index()
    {
      var settings = await _settingService.GetListAsync<Setting>(includeProperties: "User");
      return View(settings.Data);
    }
    [HttpGet]
    public async Task<IActionResult> Add()
    {
      var users = _userManager.Users.ToList();
      var usersSelectList = users
          .Select(users => new SelectListItem { Value = users.Id.ToString(), Text = users.FirstName + " " + users.LastName })
          .ToList();
      ViewBag.Users = usersSelectList;
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(SettingCRUDDto dto)
    {
      var users = _userManager.Users.ToList();
      var usersSelectList = users
          .Select(users => new SelectListItem { Value = users.Id.ToString(), Text = users.FirstName + " " + users.LastName })
          .ToList();
      ViewBag.Users = usersSelectList;
      try
      {
        if (ModelState.IsValid)
        {
          await _settingService.AddAsync(dto);
          await _settingService.SaveAsync();
          _toastNotification.AddSuccessToastMessage(Messages.SettingAdded);
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
      var settings = await _settingService.GetAsync<Setting>(a => a.Id == id);
      SettingCRUDDto dto = new SettingCRUDDto()
      {
        Id = settings.Data.Id,
        Name = settings.Data.Name,
        Value = settings.Data.Value,
        UserId = settings.Data.UserId
      };
      var user = await _userManager.FindByIdAsync(settings.Data.UserId.ToString());
      string userName = user.FirstName + " " + user.LastName;
      ViewBag.userName = userName;
      return View(dto);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(SettingCRUDDto dto)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _settingService.Update(dto);
          await _settingService.SaveAsync();
          _toastNotification.AddWarningToastMessage(Messages.SettingUpdated);
          return RedirectToAction("Index");
        }
      }
      catch (Exception)
      {
        ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");
        TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
      }
      var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
      ViewBag.UserName = user.FirstName + " " + user.LastName;
      return View(dto);
    }
    [HttpGet]

		[Authorize(Roles = "Superadmin")]

		public async Task<IActionResult> Delete(int id)
    {
      var settings = await _settingService.GetAsync<Setting>(a => a.Id == id);
      SettingCRUDDto dto = new SettingCRUDDto()
      {
        Id = settings.Data.Id,
        Name = settings.Data.Name,
        Value = settings.Data.Value,
        UserId = settings.Data.UserId,
      };
      var user = await _userManager.FindByIdAsync(settings.Data.UserId.ToString());
      string userName = user.FirstName + " " + user.LastName;
      ViewBag.userName = userName;
      return View(dto);
    }
    [HttpPost]

		[Authorize(Roles = "Superadmin")]

		public async Task<IActionResult> Delete(SettingCRUDDto dto)
    {
      if (ModelState.IsValid)
      {
        _settingService.Delete(dto);
        await _settingService.SaveAsync();
      }
      _toastNotification.AddErrorToastMessage(Messages.SettingDeleted);
      return RedirectToAction("Index", "Setting", new { area = "Admin" });
    }
  }
}
