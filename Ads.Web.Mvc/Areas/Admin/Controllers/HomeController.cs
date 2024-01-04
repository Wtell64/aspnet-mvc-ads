
using Ads.Business.Abstract;
using Ads.Business.Dtos.Admin;
using Ads.Business.Dtos.Users;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{

  [Area("Admin")]
	[Authorize(Roles = "Admin,Superadmin")]
	public class HomeController : Controller
  {

    private readonly UserManager<AppUser> _userManager;
    private readonly ICategoryService _categoryService;
    private readonly IAdvertService _advertService;
    private readonly ICityService _cityService;

    public HomeController(UserManager<AppUser> userManager, ICategoryService categoryService, IAdvertService advertService, ICityService cityService)
    {
      _userManager = userManager;
      _categoryService = categoryService;
      _advertService = advertService;
      _cityService = cityService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var adverts = _advertService.GetList<Advert>().Data;
      var advertWithHighestPrice = adverts.OrderByDescending(a => a.Price).FirstOrDefault();


      if (User.Identity.IsAuthenticated)
      {
        var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);
        TempData["User"] = $"{hasUser.FirstName} {hasUser.LastName}";
      }

      HomeIndexDto homeIndexDto = new HomeIndexDto()
      {
        PieDtos = CreatePopularCategoriesData(),
        UserCount = _userManager.Users.Count(),
        TotalAdvertCount = adverts.Count(),
        CityAvailablePercentage = _cityService.GetList<City>().Data.Count() * 100 / 81,
        HighestAdvertPrice = advertWithHighestPrice.Price,
        HighestAdvertTitle = advertWithHighestPrice.Title
      };
      return View(homeIndexDto);
    }

    public IActionResult PopularCategoriesPie()
    {
      return Json(new { Dto = CreatePopularCategoriesData() });
    }

    public IActionResult AdvertsByMonth()
    {
      return Json(new { Dto = CreateAdvertsByMonthData() });
    }

    [HttpGet]
    public async Task<IActionResult> UserList()
    {
      var userList = await _userManager.GetUsersInRoleAsync("user");

      var userVieModelList = userList.Select(uvd => new UserViewDto()
      {
        Id = uvd.Id,
        FirstName = uvd.FirstName,
        LastName = uvd.LastName,
        Email = uvd.Email,
      }).ToList();

      return View(userVieModelList);
    }

    private AdvertsByMonthAreaDto CreateAdvertsByMonthData()
    {
      AdvertsByMonthAreaDto dto = new AdvertsByMonthAreaDto();
      var adverts = _advertService.GetList<Advert>();

      foreach (var advert in adverts.Data)
      {
        dto.AdvertCountPerMonth[advert.CreatedDate.Month - 1]++;
      }

      return dto;
    }

    private List<PopularCategoriesPieDto> CreatePopularCategoriesData()
    {
      var dto = new List<PopularCategoriesPieDto>();

      string[] colorList = new string[] { "#4e73df", "#1cc88a", "#36b9cc", "#f3e600", "#ff4444" };


      var categories = _categoryService.GetList<Category>(null, null, "Subcategories.SubcategoryAdverts.Advert");

      var popularCategories = categories.Data
        .OrderByDescending(category => category.Subcategories
            .SelectMany(subcategory => subcategory.SubcategoryAdverts)
            .Sum(subcategoryAdvert => subcategoryAdvert.Advert.ClickCount ?? 0))
        .Take(5)
        .ToList();

      foreach (var category in popularCategories)
      {
        dto.Add(new PopularCategoriesPieDto
        {
          CategoryLabel = category.Name,
          AdvertCount = category.Subcategories.SelectMany(x => x.SubcategoryAdverts).Select(x => x.Advert).Count(),
          Color = colorList[popularCategories.IndexOf(category)]
        });
      }

      return dto;
    }
  }

}
