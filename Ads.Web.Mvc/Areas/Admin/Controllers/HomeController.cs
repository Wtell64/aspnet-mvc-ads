using Ads.Business.Abstract;
using Ads.Business.Dtos.Admin;
using Ads.Business.Dtos.Users;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class HomeController : Controller
  {

    private readonly UserManager<AppUser> _userManager;
    private readonly ICategoryService _categoryService;
    public HomeController(UserManager<AppUser> userManager, ICategoryService categoryService)
    {
      _userManager = userManager;
      _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      HomeIndexDto homeIndexDto = new HomeIndexDto() { PieDtos = CreatePopularCategoriesData() };

      return View(homeIndexDto);
    }

    public IActionResult PopularCategoriesPie()
    {
      return Json(new { Dto = CreatePopularCategoriesData() });
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

    private List<PieDto> CreatePopularCategoriesData()
    {
      var dto = new List<PieDto>();

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
        dto.Add(new PieDto
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
