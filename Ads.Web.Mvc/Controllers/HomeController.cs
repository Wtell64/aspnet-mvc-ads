
using Ads.Business.Abstract;
using Ads.Business.Dtos.Advert;
using Ads.Business.Dtos.AdvertImage;
using Ads.Business.Dtos.Category;
using Ads.Core.Utilities.Images;
using Ads.Entities.Concrete;
using Ads.Web.Mvc.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

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



    public HomeController(ILogger<HomeController> logger,
    IAdvertService advertService,
    ICategoryService categoryService,
    IWebHostEnvironment environment,
    IAdvertImageService advertImageService,
    IImageProcessor imageProcessor
    )
    {
      _logger = logger;
      _environment = environment;
      _advertService = advertService;
      _categoryService = categoryService;
      _advertImageService = advertImageService;
      _imageProcessor = imageProcessor;
    }

    public IActionResult Index()
    {
      try
      {

        return View();
      }
      catch (Exception ex)
      {
        _logger.LogInformation("Index de hat olustu");
        throw;
      }
    }
    [HttpGet]
    public async Task<IActionResult> AdListing()
    {
      var categories = await _categoryService.GetListAsync<CategoryViewDto>();
      var categoryTitles = categories.Data.Select(category => category).ToList();

      //var viewModel = new AdListingViewModel
      //{
      //  Categories = categoryTitles.Select(category => new SelectListItem { Value = category.Id.ToString(), Text = category.Name }).ToList()
      //};

      // Convert categories to SelectListItem
      var categorySelectList = categoryTitles
          .Select(category => new SelectListItem { Value = category.Id.ToString(), Text = category.Name })
          .ToList();

      // Set the SelectList in ViewBag
      ViewBag.Categories = new SelectList(categorySelectList, "Value", "Text");


      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdListing([FromForm] AdvertAddDto dto)
    {
      //TODO: Take userid from cache once its done
      //TODO: make it create the path if it does not exist
      //TODO: Make code better

      //var fileName = "";
      try
      {
        //Foto Kontrol ve kaydetme
        //core helper

        var result = await _advertService.AddAndSaveAsync(dto);
        var advertId = result.Data.Id;

        //Add Advert Categories

        foreach (var category in dto.SelectedCategoryIds)
        {
          await _advertService.AddAdvertCategoryAsync(new CategoryAdvertViewDto() { AdvertId = advertId, CategoryId = category });
        }
        await _advertService.SaveAsync();

        if (dto.Files != null && dto.Files.Count > 0)
        {
          foreach (var file in dto.Files)
          {
           string fileName = await _imageProcessor.SaveImageAsync(file, advertId); 
           _advertImageService.Add(new AdvertImageViewDto() { AdvertId = advertId, ImagePath = fileName });
           _advertImageService.Save();
          }
        }
        SetCategoryViewData();


        //make it a single one process

        //save data as before


        //#region 
        //if (dto.Files != null && dto.Files.Count > 0)
        //{
        //  //dto.AdvertAddDto.AdvertImages = new List<AdvertImage>();

        //  foreach (var file in dto.Files)
        //  {
        //    if (file.ContentType.StartsWith("image/"))
        //    {
        //      // Check file size (in bytes), for example, limit it to 1000 KB
        //      const int maxFileSize = 1000 * 1024;

        //      if (file.Length > maxFileSize)
        //      {
        //        // File size exceeds the limit, handle accordingly (e.g., return an error message)
        //        ModelState.AddModelError("File", "File size exceeds the limit. Please upload a file smaller than 1000 KB.");
        //        continue;
        //      }

        //      // Resize the image before saving
        //      using (var stream = new MemoryStream())
        //      {
        //        await file.CopyToAsync(stream);

        //        stream.Seek(0, SeekOrigin.Begin);

        //        using (var image = Image.Load(stream))
        //        {
        //           image.Mutate(x => x
        //              .Resize(new ResizeOptions
        //              {
        //                Size = new Size(610, 400),
        //                Mode = ResizeMode.Max // Ratio sabit kalicak. Buyuk olani aliyor.
        //              }));

        //          // Save the resized image
        //          fileName = Path.GetFileName(file.FileName);
        //          var savePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);



        //          image.Save(savePath);


        //           AdvertImageViewDto advertImageViewDto = new AdvertImageViewDto() { AdvertId = advertId, ImagePath = fileName };
        //          _advertImageService.Add(advertImageViewDto);
        //          _advertImageService.Save();

        //          //AdvertImage saveImage = new AdvertImage() { ImagePath = savePath };

        //          //dto.AdvertAddDto.AdvertImages.Add(saveImage);

        //        }
        //      }
        //    }
        //    else
        //    {
        //      ModelState.AddModelError("File", "Invalid file type. Please upload an image.");
        //    }



        //  }
        //}
        //#endregion

        //controller alti fonksiyon
        var categories = await _categoryService.GetListAsync<CategoryViewDto>();
        var categoryTitles = categories.Data.Select(category => category).ToList();
        var categorySelectList = categoryTitles
          .Select(category => new SelectListItem { Value = category.Id.ToString(), Text = category.Name })
          .ToList();

        // Set the SelectList in ViewBag
        ViewBag.Categories = new SelectList(categorySelectList, "Value", "Text");





        if (ModelState.IsValid)
        {
          TempData["SuccessMessage"] = "Ad posted successfully!";
        }


      }
      catch (Exception ex)
      {

        // Log the exception or handle it as needed
        ModelState.AddModelError("Error", "An error occurred while processing the form.");

        // Error message
        TempData["ErrorMessage"] = "An error occurred. Please try again.";
      }
      return View(dto);

     }

    private void SetCategoryViewData()
    {
      var categories = _categoryService.GetListAsync<CategoryViewDto>().Result.Data;
      var categoryTitles = categories.Select(category => category).ToList();
      var categorySelectList = categoryTitles
          .Select(category => new SelectListItem { Value = category.Id.ToString(), Text = category.Name })
          .ToList();

      ViewBag.Categories = new SelectList(categorySelectList, "Value", "Text");
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