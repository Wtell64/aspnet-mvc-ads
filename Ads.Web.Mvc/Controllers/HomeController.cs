
using Ads.Business.Abstract;
using Ads.Business.Dtos.Advert;
using Ads.Business.Dtos.AdvertImage;
using Ads.Business.Dtos.Category;
using Ads.Core.Utilities.Images;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Ads.Web.Mvc.Controllers
{




  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IAdvertService _advertService;
    private readonly IAdvertImageService _advertImageService;
    private readonly ICategoryService _categoryService;
    private readonly IWebHostEnvironment _environment;
    private readonly IImageProcessor _imageProcessor;
    private readonly ISubcategoryService _subcategoryService;
    private readonly UserManager<AppUser> _userManager;



    public HomeController(ILogger<HomeController> logger,
    IAdvertService advertService,
    ICategoryService categoryService,
    IWebHostEnvironment environment,
    IAdvertImageService advertImageService,
    IImageProcessor imageProcessor,
    ISubcategoryService subcategoryService,
    UserManager<AppUser> userManager
    )
    {
      _logger = logger;
      _environment = environment;
      _advertService = advertService;
      _categoryService = categoryService;
      _advertImageService = advertImageService;
      _imageProcessor = imageProcessor;
      _subcategoryService = subcategoryService;
      _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {

      try
      {
        throw new Exception("asdfasd");
        if (User.Identity.IsAuthenticated)
        {

          var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);
          TempData["User"] = $"{hasUser.FirstName} {hasUser.LastName}";
        }
        return View();
      }
      catch (Exception ex)
      {
        _logger.LogInformation("Index de hata olustu");
        throw;
      }
    }
    [HttpGet]
    public async Task<IActionResult> AdListing()
    {
      var subcategoryList = await SetCategoryViewDataAsync();

      ViewBag.Subcategories = new SelectList(subcategoryList, "Value", "Text");

      return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdListing([FromForm] AdvertAddDto dto)
    {

      //TODO: make it create the path if it does not exist


      //var fileName = "";
      try
      {
        if (User.Identity.IsAuthenticated)
        {
          var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);
          dto.UserId = hasUser.Id;
        }
        var result = await _advertService.AddAndSaveAsync(dto);

        var advertId = result.Data.Id;

        //Add Advert Categories

        foreach (var subategory in dto.SelectedSubategoryIds)
        {
          await _advertService.AddAdvertSubcategoryAsync(new SubcategoryAdvertViewDto() { AdvertId = advertId, SubcategoryId = subategory });
        }
        await _advertService.SaveAsync();

        if (dto.Files != null && dto.Files.Count > 0)
        {
          foreach (var file in dto.Files)
          {
            string fileName = await _imageProcessor.SaveImageAsync(file, advertId, "uploads");
            _advertImageService.Add(new AdvertImageViewDto() { AdvertId = advertId, ImagePath = fileName });
            _advertImageService.Save();
          }
        }
        var subcategoryList = await SetCategoryViewDataAsync();

        ViewBag.Subcategories = new SelectList(subcategoryList, "Value", "Text");

        if (ModelState.IsValid)
        {
          TempData["SuccessMessage"] = "Reklam başarıyla keydedildi.";
          _logger.LogInformation("Kullanıcı tarafından bir reklam eklendi.");
        }


      }
      catch (Exception ex)
      {

        // Log the exception or handle it as needed
        ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");

        // Error message
        TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
        _logger.LogInformation("Kullanıcı tarafından bir reklam eklenirken bir hata oluştu.");
      }
      return View(dto);

    }

    private async Task<List<SelectListItem>> SetCategoryViewDataAsync()
    {
      var subcategories = await _subcategoryService.GetListAsync<Subcategory>();
      var subcategoriesTitles = subcategories.Data.Select(subcategory => subcategory).ToList();
      var categorySelectList = subcategoriesTitles
          .Select(subcategory => new SelectListItem { Value = subcategory.Id.ToString(), Text = subcategory.Name })
          .ToList();

      return categorySelectList;
    }

    private void HandleSuccessMessage()
    {
      if (ModelState.IsValid)
      {
        TempData["SuccessMessage"] = "Ad posted successfully!";
      }
    }

    private void HandleError()
    {
      ModelState.AddModelError("Error", "An error occurred while processing the form.");
      TempData["ErrorMessage"] = "An error occurred. Please try again.";
    }
  }
}