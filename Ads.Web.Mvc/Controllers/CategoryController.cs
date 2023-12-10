using Ads.Business.Abstract;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ads.Web.Mvc.Controllers
{
  public class CategoryController : Controller
  {
    private readonly IAdvertService _advertService;
    private readonly ISubcategoryService _subcategoryService;

		public CategoryController(ISubcategoryService subcategoryService, IAdvertService advertService)
		{
			_subcategoryService = subcategoryService;
			_advertService = advertService;
		}
		[Route("/Category/{category-slug}-{id}")]
    public async Task<IActionResult> Index(int id, int page) //id = category id, page = sayfalanma
    {
      var subcategory = await _subcategoryService.FindByIdAsync<Subcategory>(id);
      if (subcategory == null)  return RedirectToAction("Index","Home");
      var adverts = await _advertService.GetListAsync<Advert>(a => a.SubcategoryAdverts.Any(x => x.SubcategoryId == subcategory.Data.Id),null, "SubcategoryAdverts.Subcategory.Category,User.Address.City,User.AdvertComments");

      var totalPostCount = adverts.Data.Count();
      var postCountPerPage = 9; //10
      var pageCount = Math.Ceiling((double)totalPostCount / postCountPerPage);
      if (page <= 0) page = 1;
      if (page > pageCount) page = (int)pageCount;

      ViewBag.PageCount = pageCount;

      //Setting up the viewbags for the data filtering on the sidebar

      var subcategoryCounts = adverts.Data
          .SelectMany(a => a.SubcategoryAdverts.Select(ca => ca.Subcategory.Category.Name))
          .GroupBy(name => name)
          .Select(group => new { Subcategory = group.Key, Count = group.Count() })
          .ToList();

      ViewBag.Subcategories = subcategoryCounts;

      var countryCounts = adverts.Data
        .Where(a => a.User != null && a.User.Address != null && a.User.Address.City != null)
        .GroupBy(a => a.User.Address.City.Name)
        .Select(group => new { Country = group.Key, Count = group.Count() })
        .ToList();

      ViewBag.Countries = countryCounts;

      var conditions = adverts.Data
          .SelectMany(a => a.SubcategoryAdverts.Select(ca => ca.Subcategory.Category.Name))
          .GroupBy(name => name)
          .Select(group => new { Subcategory = group.Key, Count = group.Count() })
          .ToList();

      ViewBag.ConditionEnumValues = Enum.GetValues(typeof(AdvertConditionEnum))
                                  .Cast<AdvertConditionEnum>()
                                  .Select(e => new SelectListItem
                                  {
                                    Value = ((int)e).ToString(),
                                    Text = e.ToString()
                                  })
      .ToList();

      var advertsPageified = adverts.Data
      .Skip((page - 1) * postCountPerPage).Take(postCountPerPage);

      ViewBag.AdvertCount = totalPostCount;
     /* ViewBag.Query = query;
      ViewBag.Category = category;
      ViewBag.Location = location;
      ViewBag.MinPrice = minPrice;
      ViewBag.MaxPrice = maxPrice;
      ViewBag.Condition = condition;*/


      return View(advertsPageified);
    }
  }
}


