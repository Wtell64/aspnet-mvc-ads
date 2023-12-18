using Ads.Business.Abstract;
using Ads.Business.Constants;
using Ads.Business.Dtos.Category;
using Ads.Core.Entities.Abstract;
using Ads.Entities.Concrete;
using App.Core.Utilities.Results;
using AutoMapper;
using FutureCafe.Core.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class CategoryController : Controller
  {
    private readonly ICategoryService _categoryService;


    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;

    }

    public async Task<IActionResult> Index()
    {
      var result = await _categoryService.GetListAsync<CategoryViewDto>();
      if (result.Success)
      {
        var categoryDtoList = result.Data;
        return View(categoryDtoList);
      }
      else
      {
        ModelState.AddModelError(string.Empty, result.Message);
        return View();
      }
    }
    [HttpGet]
    public IActionResult Create()
    {

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryViewDto dto)
    {
      if (dto == null) { return RedirectToAction("Index"); }
      var validationResult = _categoryService.Validate(dto);
      if (validationResult.Data.IsValid == false)
      {
        validationResult.Data.AddToModelState(this.ModelState);
        return View(dto);
      }
      await _categoryService.AddAsync<CategoryViewDto>(dto);
      await _categoryService.SaveAsync();
      return RedirectToAction("Index");
    }
    //if (ModelState.IsValid) 
    //{
    // var result= await _categoryService.AddAsync(dto);
    //  _categoryService.Save();
    //  if (result.Success)
    //  {

    //   return RedirectToAction("Index");
    //  }
    //  else
    //  {
    //    ModelState.AddModelError(string.Empty, result.Message);
    //  }
  //}
      //return View(dto);
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id) 
    {
      if (id == 0) { return RedirectToAction("Index"); }
      var category = await _categoryService.FindByIdAsync<CategoryViewDto>(id);

      if (category == null) { return RedirectToAction("Index"); }

      return View(category.Data);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(CategoryViewDto dto)
    {
     if(dto == null ) { return RedirectToAction("Index"); }
     var validationResult = _categoryService.Validate(dto);
     if (validationResult.Data.IsValid==false) 
     { validationResult.Data.AddToModelState(this.ModelState); return View(dto); }

     _categoryService.Update(dto);
     await _categoryService.SaveAsync();

      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
      if (id == 0) { return RedirectToAction("Index"); }

      var category = await _categoryService.FindByIdAsync<CategoryViewDto>(id);

      if (category == null)
      { return RedirectToAction("Index"); }

      return View(category.Data);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int id)
    {
      if (id == 0) { return RedirectToAction("Index"); }

      _categoryService.DeleteById(id);
      await _categoryService.SaveAsync();

      return RedirectToAction("Index");
    }
  }
}
