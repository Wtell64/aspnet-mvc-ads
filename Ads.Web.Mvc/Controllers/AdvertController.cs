using Ads.Business.Abstract;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Enums;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace Ads.Web.Mvc.Controllers
{



  public class AdvertController : Controller
  {
    private readonly IAdvertService _advertService;
    private readonly IAdvertCommentService _advertCommentService;
    private readonly IAdvertImageService _advertImageService;
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<AdvertController> _logger;

    public AdvertController(IAdvertService advertService, IAdvertCommentService advertCommentService, IAdvertImageService advertImageService, UserManager<AppUser> userManager, ILogger<AdvertController> logger)
    {
      _advertService = advertService;
      _advertCommentService = advertCommentService;
      _advertImageService = advertImageService;
      _userManager = userManager;
      _logger = logger;
    }
    public IActionResult Search(string query, string category, string location, int page = 1, decimal minPrice = 0, decimal maxPrice = 5000, int condition = 999)
    {
      var adverts = _advertService.GetList<Advert>(filter: a => a.Price >= minPrice && a.Price <= maxPrice, includeProperties: "SubcategoryAdverts.Subcategory.Category,User.Address.City,User.AdvertComments,AdvertImages").Data;

      if (condition != 999)
      {
        adverts = adverts.Where(a => a.ConditionEnum == (AdvertConditionEnum)condition);
      }

      if (!string.IsNullOrEmpty(query))
      {
        adverts = adverts.Where(a => a.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || a.Description.Contains(query, StringComparison.OrdinalIgnoreCase));
      }

      if (!string.IsNullOrEmpty(category))
      {
        adverts = adverts.Where(a => a.SubcategoryAdverts.Any(ca => ca.Subcategory.Category.Name.ToLower() == category.ToLower() || ca.Subcategory.Name.ToLower() == category.ToLower()));
      }

      if (!string.IsNullOrEmpty(location))
      {
        adverts = adverts.Where(a => a.User.Address != null && (a.User.Address.City.Name.ToLower() == location.ToLower() || a.User.Address.Country.ToLower() == location.ToLower()));
      }

      var totalPostCount = adverts.Count();
      var postCountPerPage = 9; //10
      var pageCount = Math.Ceiling((double)totalPostCount / postCountPerPage);
      if (page <= 0) page = 1;
      if (page > pageCount) page = (int)pageCount;

      ViewBag.PageCount = pageCount;

      //Setting up the viewbags for the data filtering on the sidebar

      var subcategoryCounts = adverts
          .SelectMany(a => a.SubcategoryAdverts.Select(ca => ca.Subcategory.Category.Name))
          .GroupBy(name => name)
          .Select(group => new { Subcategory = group.Key, Count = group.Count() })
          .ToList();

      ViewBag.Subcategories = subcategoryCounts;

      var countryCounts = adverts
        .Where(a => a.User != null && a.User.Address != null && a.User.Address.City != null)
        .GroupBy(a => a.User.Address.City.Name)
        .Select(group => new { Country = group.Key, Count = group.Count() })
        .ToList();

      ViewBag.Countries = countryCounts;

      var conditions = adverts
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

      var advertsPageified = adverts
      .Skip((page - 1) * postCountPerPage).Take(postCountPerPage);

      ViewBag.AdvertCount = totalPostCount;
      ViewBag.Query = query;
      ViewBag.Category = category;
      ViewBag.Location = location;
      ViewBag.MinPrice = minPrice;
      ViewBag.MaxPrice = maxPrice;
      ViewBag.Condition = condition;


      return View(advertsPageified);

    }
    [HttpPost]
    public IActionResult Search(string query, string location, string category)
    {
      return RedirectToAction("Search", new { query, location, category, page = 1 });
    }

    public IActionResult ChangePage(int page, string query, string category, string location, decimal minPrice, decimal maxPrice, int condition)
    {
      return RedirectToAction("Search", new { query, location, category, page, minPrice, maxPrice, condition });
    }

    [Route("/advert/{titleSlug}-{id}")]
    public async Task<IActionResult> Detail(int id)
    {
      var advert = _advertService.Get<Advert>(a => a.Id == id, "User.Address.City,User.Address.District,AdvertComments.User,AdvertImages,SubcategoryAdverts.Subcategory");
      var user = User.Identity.Name != null ? await _userManager.FindByEmailAsync(User.Identity.Name) : null;
      ViewBag.userName = user != null ? user.FirstName + " " + user.LastName : "Misafir";
      advert.Data.ClickCount = advert.Data.ClickCount + 1;
      _advertService.Update(advert.Data);
      _advertService.Save();
      return View(advert.Data);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitComment(int advId, string review, int starCount)
    {
      if (starCount == 0) starCount = 3;

      var user = User.Identity.Name != null ? await _userManager.FindByEmailAsync(User.Identity.Name) : null;
      if (user == null) return RedirectToAction("Detail", "Advert", new { id = advId });

      var advert = _advertService.Get<Advert>(a => a.Id == advId, "AdvertComments");
      if (advert == null) return RedirectToAction("Detail", "Advert", new { id = advId });

      advert.Data.AdvertComments.Add(new AdvertComment { UserId = user.Id, Comment = review, StarCount = starCount });
      _advertService.Update(advert.Data);
      await _advertService.SaveAsync();

      return RedirectToAction("Detail", "Advert", new { id = advId, titleSlug = advert.Data.Title});
    }


  }
}
