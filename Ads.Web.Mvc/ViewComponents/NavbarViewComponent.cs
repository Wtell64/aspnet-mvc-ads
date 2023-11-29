﻿using Ads.Business.Abstract;
using Ads.Business.Dtos.Navbar;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.ViewComponents
{
  public class NavbarViewComponent : ViewComponent
  {
    IPageService _pageService;
    ICategoryService _categoryService;
    public NavbarViewComponent(IPageService pageService, ICategoryService categoryService)
    {
      _pageService = pageService;
      _categoryService = categoryService;
    }

    public IViewComponentResult Invoke()
    {
      var pages = _pageService.GetList<Page>();
      var categories = _categoryService.GetList<Category>();

      //var navbarViewDto = new NavbarViewDto() { CategoryNames = new List<string>(), PageTitles = new List<string>() };

      //foreach (var page in pages.Data)
      //{
      //  navbarViewDto.PageTitles.Add(page.Title);
      //}
      //foreach (var category in categories.Data)
      //{
      //  navbarViewDto.CategoryNames.Add(category.Name);
      //}
      var navbarViewDto = new NavbarViewDto();
      navbarViewDto.Categories = categories.Data;
      navbarViewDto.Pages = pages.Data;
      return View(navbarViewDto);
    }
  }
}
