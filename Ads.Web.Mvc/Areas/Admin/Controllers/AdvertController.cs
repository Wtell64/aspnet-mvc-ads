﻿using Ads.Business.Abstract;
using Ads.Business.Dtos.Advert;
using Ads.Business.Dtos.AdvertImage;
using Ads.Business.Dtos.Category;
using Ads.Core.Utilities.Images;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class AdvertController : Controller
  {
    private readonly IAdvertService _advertService;
    private readonly IAdvertImageService _advertImageService;
    private readonly IAdvertCommentService _advertCommentService;
    private readonly ISubcategoryService _subcategoryService;
    private readonly ILogger<HomeController> _logger;
    private readonly IImageProcessor _imageProcessor;
    private readonly UserManager<AppUser> _userManager; 
    public AdvertController(IAdvertService advertService, IAdvertImageService advertImageService, IAdvertCommentService advertCommentService, ISubcategoryService subcategoryService, ILogger<HomeController> logger, IImageProcessor imageProcessor,
    UserManager<AppUser> userManager
    )
    {
      _advertService = advertService;
      _advertImageService = advertImageService;
      _advertCommentService = advertCommentService;
      _subcategoryService = subcategoryService;
      _logger = logger;
      _imageProcessor = imageProcessor;
      _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index() //
    {
      var adverts = await _advertService.GetListAsync<Advert>(includeProperties: "User,SubcategoryAdverts.Subcategory.Category");
      var advertsList = adverts.Data;
      return View(advertsList);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
      var subcategoryList = await SetCategoryViewDataAsync();
      ViewBag.Subcategories = new SelectList(subcategoryList, "Value", "Text");

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AdvertAdminAddDto dto)
    {

      try
      {
        //TODO: Session gelince degistir
        var result = await _advertService.AddAndSaveAsync(dto);
        var advertId = result.Data.Id;

        foreach (var subategory in dto.SelectedSubategoryIds)
        {
          await _advertService.AddAdvertSubcategoryAsync(new SubcategoryAdvertViewDto() { AdvertId = advertId, SubcategoryId = subategory });
        }
        await _advertService.SaveAsync();


        var subcategoryList = await SetCategoryViewDataAsync();
        ViewBag.Subcategories = new SelectList(subcategoryList, "Value", "Text");

        if (ModelState.IsValid)
        {
          TempData["SuccessMessage"] = "Reklam başarıyla keydedildi.";
        }
      }
      catch (Exception)
      {
        ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");
        TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
      }
      return View();
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var subcategoryList = await SetCategoryViewDataAsync();
      ViewBag.Subcategories = new SelectList(subcategoryList, "Value", "Text");

      var advert = await _advertService.GetAsync<AdvertAdminAddDto>(x => x.Id == id);

      return View(advert.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AdvertAdminAddDto dto)
    {

      try
      {
        var advertId = dto.Id;
        //TODO: Session gelince degistir
        var advert =  _advertService.Update(dto);

        var subcategories = await _advertService.GetSubcategoryListAsync<SubcategoryAdvert>(filter: x => x.AdvertId == advertId);
        foreach (var subcategory in subcategories.Data)
        { 
          _advertService.DeleteSubcategory(subcategory);
        }

        foreach (var subategory in dto.SelectedSubategoryIds)
        {
          await _advertService.AddAdvertSubcategoryAsync(new SubcategoryAdvertViewDto() { AdvertId = advertId, SubcategoryId = subategory });
        }
        await _advertService.SaveAsync();


        var subcategoryList = await SetCategoryViewDataAsync();
        ViewBag.Subcategories = new SelectList(subcategoryList, "Value", "Text");

        if (ModelState.IsValid)
        {
          TempData["SuccessMessage"] = "Reklam başarıyla güncellendi.";
        }
      }
      catch (Exception)
      {
        ModelState.AddModelError("Error", "Güncelleme sırasında bir hata oluştu");
        TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
      }
      return View(dto);
    }

    [HttpPost]
    public async  Task<IActionResult> Remove(int id)
    {
      //var advert = await _advertService.GetAsync<Advert>(filter: x => x.Id == id);
      //var advertId = advert.Data.Id;

      //var subcategories = await _advertService.GetSubcategoryListAsync<SubcategoryAdvert>(filter: x => x.AdvertId == advertId);
      //foreach (var subcategory in subcategories.Data)
      //{
      //  _advertService.DeleteSubcategory(subcategory);
      //}

      _advertService.DeleteById(id);
      await _advertService.SaveAsync();

      return RedirectToAction("Index", "Advert", new { area = "Admin" });
    }


    public async Task<IActionResult> ImageIndex(int id)
    {
      var advertImages = await _advertImageService.GetListAsync<AdvertImage>(filter: a => a.AdvertId == id);
      var advertImagesList = advertImages.Data;

      ViewBag.AdvertId = id;

      return View(advertImagesList);
    }
    [HttpGet]
    public IActionResult ImageAdd(int id)
    {
      ViewBag.AdvertId = id;
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> ImageAdd([FromForm] AdvertImageAdminAddDto dto)
    {
      try{ 
      int advertId = dto.AdvertId;

      if (dto.Files != null && dto.Files.Count > 0)
      {
        foreach (var file in dto.Files)
        {
          string fileName = await _imageProcessor.SaveImageAsync(file, advertId, "uploads");
          _advertImageService.Add(new AdvertImageViewDto() { AdvertId = advertId, ImagePath = fileName });
          _advertImageService.Save();
        }
      }
        if (ModelState.IsValid)
        {
          TempData["SuccessMessage"] = "Reklam başarıyla keydedildi.";
        }
      }
      catch (Exception)
      {
        ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");
        TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
      }
      return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> ImageRemove(int id)
    {

        var image = _advertImageService.Get<AdvertImage>(filter: x => x.Id == id);
        var imagePath = image.Data.ImagePath;
        var advertId = image.Data.AdvertId;
        bool result = await _imageProcessor.DeleteImageAsync(imagePath,"uploads");
        if (result)
        {
          _advertImageService.DeleteById(id);
          await _advertImageService.SaveAsync();

        }

      return RedirectToAction("ImageIndex", "Advert", new { area = "Admin" , id = advertId });
    }



    public async Task<IActionResult> CommentIndex(int id)
    {
       var advertComments = await _advertCommentService.GetListAsync<AdvertComment>(filter: a => a.AdvertId == id, includeProperties: "Advert.User");
      var advertCommentsList = advertComments.Data;

      ViewBag.AdvertId = id;

      return View(advertCommentsList);
    }
    [HttpGet]
    public async Task<IActionResult> CommentAdd(int id)
    {
      
      var users = _userManager.Users.ToList();
      var usersSelectList = users
          .Select(users => new SelectListItem { Value = users.Id.ToString(), Text = users.FirstName + " " + users.LastName })
          .ToList();
      ViewBag.Users = usersSelectList;
      ViewBag.AdvertId = id;
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> CommentAdd(AdvertCommentAdminAddDto dto)
    {
      try
      {
        var result = await _advertCommentService.AddAsync(dto);
        await _advertCommentService.SaveAsync();


        var users = _userManager.Users.ToList();
        var usersSelectList = users
            .Select(users => new SelectListItem { Value = users.Id.ToString(), Text = users.FirstName + " " + users.LastName })
            .ToList();
        ViewBag.Users = usersSelectList;
        ViewBag.AdvertId = dto.AdvertId;

        if (ModelState.IsValid)
        {
          TempData["SuccessMessage"] = "Reklam başarıyla keydedildi.";
        }
      }
      catch (Exception)
      {
        ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");
        TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
      }
      
      return View();
    }
    [HttpGet]
    public async Task<IActionResult> CommentEdit(int id)
    {

      var comment = await _advertCommentService.GetAsync<AdvertCommentAdminAddDto>(filter: x => x.Id == id);

      var users = _userManager.Users.ToList();
      var usersSelectList = users
          .Select(users => new SelectListItem { Value = users.Id.ToString(), Text = users.FirstName + " " + users.LastName })
          .ToList();
      ViewBag.Users = usersSelectList;
      ViewBag.AdvertId = comment.Data.AdvertId;
      return View(comment.Data);
    }
    [HttpPost]
    public async Task<IActionResult> CommentEdit(AdvertCommentAdminAddDto dto)
    {
      try
      {
        
        //TODO: Session gelince degistir
        var advert = _advertCommentService.Update(dto);
        await _advertCommentService.SaveAsync();

        var users = _userManager.Users.ToList();
        var usersSelectList = users
            .Select(users => new SelectListItem { Value = users.Id.ToString(), Text = users.FirstName + " " + users.LastName })
            .ToList();
        ViewBag.Users = usersSelectList;
        ViewBag.AdvertId = dto.AdvertId;

        if (ModelState.IsValid)
        {
          TempData["SuccessMessage"] = "Reklam başarıyla güncellendi.";
        }
      }
      catch (Exception)
      {
        ModelState.AddModelError("Error", "Güncelleme sırasında bir hata oluştu");
        TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
      }
      return View(dto);
    }
    [HttpPost]
    public async Task<IActionResult> CommentRemove(int id)
    {
      var comment = await _advertCommentService.FindByIdAsync<AdvertCommentAdminAddDto>(id);
      var advertId = comment.Data.AdvertId;
      try
      {
        _advertCommentService.DeleteById(id);
        await _advertCommentService.SaveAsync();
      }
      catch (Exception)
      {

        throw;
      }
      return RedirectToAction("CommentIndex", "Advert", new { area = "Admin", id = advertId });
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
  }
}
