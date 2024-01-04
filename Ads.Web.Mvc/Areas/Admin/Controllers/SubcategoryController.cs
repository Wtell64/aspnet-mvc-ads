using Ads.Business.Abstract;
using Ads.Business.Constants;
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


      var subcategories = await _subcategoryService.GetListAsync<SubcategoryViewDto>(includeProperties: "Category");

      if (subcategories == null) { return RedirectToAction("Index", "Home"); }

      return View(subcategories.Data);


    }
    public async Task<IActionResult> Index1(int categoryId)
    {

      var subcategories = await _subcategoryService.GetListAsync<SubcategoryViewDto>(a => a.CategoryId == categoryId, includeProperties: "Category");
      
      if (subcategories == null) { return RedirectToAction("Index", "Home"); }
      ViewBag.CategoryId = categoryId;
      return View(subcategories.Data);

    }
    [HttpGet]
    public IActionResult Create(int categoryId) 
    {
       SubcategoryViewDto subdto = new SubcategoryViewDto(){ CategoryId=categoryId};
      
      return View(subdto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(SubcategoryViewDto subcategorydto)
    {
      try
      {
        if (subcategorydto == null) { return RedirectToAction("Index1"); }

        var validateResult = _subcategoryService.Validate(subcategorydto);
        if (validateResult.Data.IsValid == false)
        {
          validateResult.Data.AddToModelState(this.ModelState);
         
          return View(subcategorydto);
        }

        await _subcategoryService.AddAsync<SubcategoryViewDto>(subcategorydto);
        await _subcategoryService.SaveAsync();
        TempData["successMessage"] = Messages.SubCategoryAdded;

       
      }
      catch (Exception)
      {
        ModelState.AddModelError("Error", "Ekleme sırasında bir hata oluştu");
        TempData["ErrorMessage"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
      }
       return RedirectToAction("Index1",new {categoryId= subcategorydto.CategoryId});
    }
    [HttpGet]
    public async Task<IActionResult> EditAsync(int id) 
    {
      if (id == 0) { return RedirectToAction("Index1"); }
      var subcategory = await _subcategoryService.FindByIdAsync<SubcategoryViewDto>(id);
      
      if (subcategory==null) { return RedirectToAction("Index1"); }
      var categories = await _categoryService.GetListAsync<Category>();
      var categorySelectList = new SelectList(categories.Data, "Id", "Name");
      ViewBag.Categories = categorySelectList;

      return View( subcategory.Data);
    }
    [HttpPost]
    public async Task<IActionResult> EditAsync(SubcategoryViewDto subcategorydto)
    {
      try
      {
        if (subcategorydto == null) { return RedirectToAction("Index1"); }


        var validationResult = _subcategoryService.Validate(subcategorydto);
        if (validationResult.Data.IsValid == false)
        {
          validationResult.Data.AddToModelState(this.ModelState);
          return View(subcategorydto);
        }
        var categories = await _categoryService.GetListAsync<CategoryViewDto>();
        var categorySelectList = new SelectList(categories.Data, "Id", "Name");
        ViewBag.Categories = categorySelectList;

        _subcategoryService.Update(subcategorydto);
        await _subcategoryService.SaveAsync();
        TempData["successMessage"] = Messages.SubcategoryUpdated;


      }
      catch (Exception)
      {

        ModelState.AddModelError("Error", "Düzenleme sırasında bir hata oluştu");
        TempData["ErrorMessage"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
      }
      return RedirectToAction("Index1", new { categoryId = subcategorydto.CategoryId });

     
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
      var subcategorydto = await _subcategoryService.FindByIdAsync<SubcategoryViewDto>(id);

			if (id == 0) { return RedirectToAction("Index"); }

      _subcategoryService.DeleteById(id);
      await _subcategoryService.SaveAsync();
      TempData["successMessage"] = Messages.SubcategoryDeleted;

      return RedirectToAction("Index1",new { categoryId = subcategorydto.Data.CategoryId });
    }
  }
}
