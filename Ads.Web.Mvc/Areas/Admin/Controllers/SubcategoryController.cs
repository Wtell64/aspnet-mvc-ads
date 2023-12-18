using Ads.Business.Abstract;
using Ads.Business.Dtos.Category;
using Ads.Business.Dtos.Subcategory;
using Ads.Entities.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class SubcategoryController : Controller
  {
  private readonly ISubcategoryService _subcategoryService;
  private readonly ICategoryService _categoryService;

    public SubcategoryController(ISubcategoryService subcategoryService, ICategoryService categoryService)
    {
      _subcategoryService = subcategoryService;
      _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {

      var subcategories = await _subcategoryService.GetListAsync<SubcategoryViewDto>(includeProperties:"Category");

      if (subcategories == null) { return RedirectToAction("Index", "Home"); }

      return View(subcategories.Data);


    }
    [HttpGet]
    public async Task<IActionResult> Create() 
    {
      var categoriesResult = await _categoryService.GetListAsync<CategoryViewDto>();
      if (categoriesResult.Success)
      {
        var categories = categoriesResult.Data;
        ViewBag.Categories = new SelectList(categories, "Id", "Name");
      }
      
      return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(SubcategoryViewDto subdto)
    {
      if (subdto==null) { return RedirectToAction("Index"); }

      var validateResult= _subcategoryService.Validate(subdto);
      if (validateResult.Data.IsValid==false) 
      { 
      validateResult.Data.AddToModelState(this.ModelState);
      var categories = await _categoryService.GetListAsync<Category>();
      var categorySelectList = new SelectList(categories.Data, "Id", "Name");
      ViewBag.Categories = categorySelectList;
        return View(subdto);
      }
     
       await _subcategoryService.AddAsync(subdto);
       await _subcategoryService.SaveAsync();

       return RedirectToAction("Index");
      
    }
    [HttpGet]
    public async Task<IActionResult> EditAsync(int id) 
    {
      if (id == 0) { return RedirectToAction("Index"); }
      var subcategory = await _subcategoryService.FindByIdAsync<SubcategoryViewDto>(id);
      
      if (subcategory==null) { return RedirectToAction("Index"); }
      var categories = await _categoryService.GetListAsync<Category>();
      var categorySelectList = new SelectList(categories.Data, "Id", "Name");
      ViewBag.Categories = categorySelectList;

      return View( subcategory.Data);
    }
    [HttpPost]
    public async Task<IActionResult> EditAsync(SubcategoryViewDto subcategorydto)
    {
      if (subcategorydto == null) { return RedirectToAction("Index"); }

     
      var validationResult = _subcategoryService.Validate(subcategorydto);
      if (validationResult.Data.IsValid == false)
      {
        validationResult.Data.AddToModelState(this.ModelState);
        return View(subcategorydto);
      }
      var categories = await _categoryService.GetListAsync<Category>();
      var categorySelectList = new SelectList(categories.Data, "Id", "Name");
      ViewBag.Categories = categorySelectList;
      _subcategoryService.Update(subcategorydto);
      await _subcategoryService.SaveAsync();

      return RedirectToAction("Index");
    }
  
    [HttpGet]
    public async Task<IActionResult> DeleteAsync(int id)
    {
      if (id==0) { return RedirectToAction("Index"); }
      var subcategory = await _subcategoryService.FindByIdAsync<SubcategoryViewDto>(id);
      if (subcategory == null) { return RedirectToAction("Index"); }

        return View(subcategory.Data);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePostAsync(int id)
    {
      if (id == 0) { return RedirectToAction("Index"); }

      _subcategoryService.DeleteById(id);
      await _subcategoryService.SaveAsync();

      return RedirectToAction("Index");
    }
  }
}
