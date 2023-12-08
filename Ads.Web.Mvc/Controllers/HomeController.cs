﻿
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
    private readonly ISubcategoryService _subcategoryService;



    public HomeController(ILogger<HomeController> logger,
    IAdvertService advertService,
    ICategoryService categoryService,
    IWebHostEnvironment environment,
    IAdvertImageService advertImageService,
    IImageProcessor imageProcessor,
    ISubcategoryService subcategoryService
    )
    {
      _logger = logger;
      _environment = environment;
      _advertService = advertService;
      _categoryService = categoryService;
      _advertImageService = advertImageService;
      _imageProcessor = imageProcessor;
      _subcategoryService = subcategoryService;
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
      var subcategoryList = await SetCategoryViewDataAsync();

			ViewBag.Subcategories = new SelectList(subcategoryList, "Value", "Text");

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
           string fileName = await _imageProcessor.SaveImageAsync(file, advertId); 
           _advertImageService.Add(new AdvertImageViewDto() { AdvertId = advertId, ImagePath = fileName });
           _advertImageService.Save();
          }
        }
        var subcategoryList = await SetCategoryViewDataAsync();

        ViewBag.Subcategories = new SelectList(subcategoryList, "Value", "Text");

        if (ModelState.IsValid)
        {
          TempData["SuccessMessage"] = "Reklam başarıyla keydedildi.";
        }


      }
      catch (Exception ex)
      {

        // Log the exception or handle it as needed
        ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");

        // Error message
        TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
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