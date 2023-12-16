using Ads.Business.Abstract;
using Ads.Business.Dtos.City;
using FutureCafe.Core.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class CityController : Controller
  {
    ICityService _cityService;


    public CityController(ICityService cityService)
    {
      _cityService = cityService;
    }

    public async Task<IActionResult> Index()
    {

      var cities = await _cityService.GetListAsync<CityViewDto>();

      if (cities == null) return RedirectToAction("Index", "Home");

      return View(cities.Data);
    }

    //CREATE   
    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CityCreateOrEditDto cityDto)
    {
      if (cityDto == null) { RedirectToAction("Index"); }

      //validate
      var validationResult = _cityService.Validate(cityDto);
      if (validationResult.Data.IsValid == false)
      {
        validationResult.Data.AddToModelState(this.ModelState);
        return View(cityDto);
      }

      await _cityService.AddAsync<CityCreateOrEditDto>(cityDto);
      await _cityService.SaveAsync();

      return RedirectToAction("Index");
    }
    //EDIT
    public async Task<IActionResult> Edit(int id)
    {
      if (id == 0) { return RedirectToAction("Index"); }

      var city = await _cityService.FindByIdAsync<CityCreateOrEditDto>(id);

      if (city == null)
      { return RedirectToAction("Index"); }


      return View(city.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CityCreateOrEditDto cityDto)
    {
      if (cityDto == null) { return RedirectToAction("Index"); }

      //validate
      var validationResult = _cityService.Validate(cityDto);
      if (validationResult.Data.IsValid == false)
      {
        validationResult.Data.AddToModelState(this.ModelState);
        return View(cityDto);
      }

      _cityService.Update(cityDto);
      await _cityService.SaveAsync();

      return RedirectToAction("Index");
    }

    //DELETE

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
      if (id == 0) { return RedirectToAction("Index"); }

      var city = await _cityService.FindByIdAsync<CityViewDto>(id);

      if (city == null)
      { return RedirectToAction("Index"); }

      return View(city.Data);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int id)
    {
      if (id == 0) { return RedirectToAction("Index"); }

      _cityService.DeleteById(id);
      await _cityService.SaveAsync();

      return RedirectToAction("Index");
    }

  }
}
