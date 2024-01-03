using Ads.Business.Abstract;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace Ads.Web.Mvc.Controllers
{
  public class CategoryController : Controller
  {
    private readonly IAdvertService _advertService;
    private readonly ISubcategoryService _subcategoryService;
    private readonly ICategoryService _categoryService;

    public CategoryController(ISubcategoryService subcategoryService, IAdvertService advertService, ICategoryService categoryService)
    {
      _subcategoryService = subcategoryService;
      _advertService = advertService;
      _categoryService = categoryService;
    }

    [Route("/Category/{category-slug}/{categoryId}/{subcategory-slug?}/{subcategoryId?}")]
    public async Task<IActionResult> Index(int categoryId, int subcategoryId, int page = 1) //id = category id, page = sayfalanma
    {

      var subcategory = await _subcategoryService.FindByIdAsync<Subcategory>(subcategoryId);
      if (subcategory == null && subcategoryId != 0) return RedirectToAction("Index", "Home");

      var category = await _categoryService.FindByIdAsync<Category>(categoryId);
      var categoryName = category?.Data?.Name;
      ViewBag.CategoryName = categoryName;

      var adverts = subcategoryId != 0 ?
        await _advertService.GetListAsync<Advert>(a => a.SubcategoryAdverts.Any(x => x.SubcategoryId == subcategory.Data.Id), null, "SubcategoryAdverts.Subcategory.Category,User.Address.City,User.AdvertComments")
        :
        await _advertService.GetListAsync<Advert>(a => a.SubcategoryAdverts.Select(a => a.Subcategory).Any(x => x.CategoryId == categoryId), null, "SubcategoryAdverts.Subcategory.Category,User.Address.City,User.AdvertComments");

      var totalPostCount = adverts.Data.Count();
      var postCountPerPage = 9; //10
      var pageCount = Math.Ceiling((double)totalPostCount / postCountPerPage);
      if (page <= 0) page = 1;
      if (page > pageCount) page = (int)pageCount;

      ViewBag.PageCount = pageCount;

      //Setting up the viewbags for the data filtering on the sidebar

      

      var sideBarCategories = _categoryService.GetListAsync<Category>(null, null, "Subcategories.SubcategoryAdverts");

      ViewBag.SideBarCategories = sideBarCategories.Result.Data.ToList().Take(5);

      if (category.Data != null )
      {
        ViewBag.CategoryTitleName = subcategoryId != 0 ? subcategory.Data.Name + " alt kategorisinde" : category.Data.Name + " kategorisinde";
      }

      var advertsPageified = adverts.Data
      .Skip((page - 1) * postCountPerPage).Take(postCountPerPage);

      ViewBag.AdvertCount = totalPostCount;





      return View(advertsPageified);

    }

  }
}


