using Ads.Business.Abstract;
using Ads.Business.Constants;
using Ads.Business.Dtos.District;
using FutureCafe.Core.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
  [Area("Admin")]
  [Authorize(Roles = "Admin,Superadmin")]
  public class DistrictController : Controller
  {

    private readonly IDistrictService _districtService;
    private readonly IToastNotification _toastNotification;
    public DistrictController(IDistrictService districtService, IToastNotification toastNotification)
    {
      _districtService = districtService;
      _toastNotification = toastNotification;
    }

    public async Task<IActionResult> Index(int cityId)
    {

      var districts = await _districtService.GetListAsync<DistrictViewDto>(a => a.CityId == cityId);

      if (districts == null) return RedirectToAction("Index", "Home");

      ViewBag.CityId = cityId;

      return View(districts.Data);
    }

    //CREATE   
    [HttpGet]
    public IActionResult Create(int cityId)
    {
      DistrictCreateOrEditDto districtDto = new DistrictCreateOrEditDto() { CityId = cityId };
      return View(districtDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(DistrictCreateOrEditDto districtDto)
    {
      if (districtDto == null) { RedirectToAction("Index"); }

      //validate
      var validationResult = _districtService.Validate(districtDto);
      if (validationResult.Data.IsValid == false)
      {
        validationResult.Data.AddToModelState(this.ModelState);
        return View(districtDto);
      }

      await _districtService.AddAsync<DistrictCreateOrEditDto>(districtDto);
      await _districtService.SaveAsync();

      _toastNotification.AddSuccessToastMessage(Messages.DistrictAdded);

      return RedirectToAction("Index", new { cityId = districtDto.CityId });
    }

    //EDIT
    public async Task<IActionResult> Edit(int id)
    {
      if (id == 0) { return RedirectToAction("Index"); }

      var district = await _districtService.FindByIdAsync<DistrictCreateOrEditDto>(id);

      if (district == null)
      { return RedirectToAction("Index"); }


      return View(district.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(DistrictCreateOrEditDto districtDto)
    {
      if (districtDto == null) { return RedirectToAction("Index"); }

      //validate
      var validationResult = _districtService.Validate(districtDto);
      if (validationResult.Data.IsValid == false)
      {
        validationResult.Data.AddToModelState(this.ModelState);
        return View(districtDto);
      }

      _districtService.Update(districtDto);
      await _districtService.SaveAsync();

      _toastNotification.AddWarningToastMessage(Messages.DistrictEdited);

      return RedirectToAction("Index", new { cityId = districtDto.CityId });
    }

    //DELETE

    [HttpGet]
    [Authorize(Roles = "Superadmin")]
    public async Task<IActionResult> Delete(int id)
    {
      if (id == 0) { return RedirectToAction("Index"); }

      var district = await _districtService.FindByIdAsync<DistrictViewDto>(id);

      if (district == null)
      { return RedirectToAction("Index"); }

      return View(district.Data);
    }

    [HttpPost, ActionName("Delete")]
    [Authorize(Roles = "Superadmin")]
    public async Task<IActionResult> DeletePost(int id)
    {
      var districtDto = await _districtService.FindByIdAsync<DistrictViewDto>(id);

      if (id == 0) { return RedirectToAction("Index"); }

      _districtService.DeleteById(id);
      await _districtService.SaveAsync();

      _toastNotification.AddWarningToastMessage(Messages.DistrictDeleted);

      return RedirectToAction("Index", new { cityId = districtDto.Data.CityId });
    }

  }
}
