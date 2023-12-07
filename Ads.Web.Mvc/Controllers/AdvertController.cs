using Ads.Business.Abstract;
using Ads.Business.Dtos.Advert;
using Ads.Business.Dtos.AdvertComment;
using Ads.Business.Dtos.AdvertImage;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;
using System.Globalization;

namespace Ads.Web.Mvc.Controllers
{

  public class AdvertController : Controller
  {
    private readonly IAdvertService _advertService;
    private readonly IAdvertCommentService _advertCommentService;
    private readonly IAdvertImageService _advertImageService;

    public AdvertController(IAdvertService advertService, IAdvertCommentService advertCommentService, IAdvertImageService advertImageService)
    {
      _advertService = advertService;
      _advertCommentService = advertCommentService;
      _advertImageService = advertImageService;
    }
    public IActionResult Search(string query, string category = "", string location = "", int page = 1,decimal minPrice = 0, decimal maxPrice = 5000)
    {
      //TODO: Now the address is taken from the user which can have many addresses. So the ad will show on all of them
    //var adverts = _advertService.GetList<Advert>(filter: a => a.Price >= minPrice && a.Price <= maxPrice, includeProperties: "CategoryAdverts.Category,User.Addresses.City").Data;

    //  if (!string.IsNullOrEmpty(query))
    //  {
    //    adverts = adverts.Where(a => a.Title.Contains(query) || a.Description.Contains(query));
    //  }

      //if (!string.IsNullOrEmpty(category))
      //{
      //  adverts = adverts.Where(a => a.CategoryAdverts.Any(ca => ca.Category.Name == category));
      //}

      //if (!string.IsNullOrEmpty(location))
      //{
      //  adverts = adverts.Where(a => a.User.Addresses.Any(ca => ca.City.Name == location));
      //}

      //var totalPostCount = adverts.Count();
      //var postCountPerPage = 10; //10
      //var pageCount = Math.Ceiling((double)totalPostCount / postCountPerPage);
      //if (page <= 0) page = 1;
      //if (page > pageCount) page = (int)pageCount;

      //ViewBag.PageCount = pageCount;



      //// Get unique categories with counts
      //var categoryCounts = adverts
      //    .SelectMany(a => a.CategoryAdverts.Select(ca => ca.Category.Name))
      //    .GroupBy(name => name)
      //    .Select(group => new { Category = group.Key, Count = group.Count() })
      //    .ToList();

      //// Pass unique categories with counts to ViewBag
      //ViewBag.Categories = categoryCounts;

      //var countryCounts = adverts
      //    .SelectMany(a => a.User.Addresses.Select(ca => ca.Country))
      //    .Distinct()
      //    .GroupBy(name => name)
      //    .Select(group => new { Country = group.Key, Count = group.Count() })
      //    .ToList();

      //// Pass unique locations with counts to ViewBag
      //ViewBag.Countries = countryCounts;


      //var advertsPageified = adverts
      //.Skip((page - 1) * postCountPerPage).Take(postCountPerPage);

      ////ViewBag.Adverts = paginatedAdverts;
      ////ViewBag.PageCount = pageCount;
      ////ViewBag.CurrentPage = page;
      //ViewBag.Query = query;
      ////ViewBag.Category = category;
      ////ViewBag.Location = location;
      ////ViewBag.SortBy = sortBy;
      //ViewBag.AdvertCount = totalPostCount;

      

      //return View(advertsPageified);
      return View();
    }
    [HttpPost]
    public IActionResult Search(string query, string location, string category)
    {
      return RedirectToAction("Search", new { query, location, category, page =1, minPrice = 0, maxPrice = 5000 });
    }

    public IActionResult FilterByCountry(string location)
    {
      // Redirect to the Search action with the specified country
      return RedirectToAction("Search", new { location });
    }

    public IActionResult FilterByCategory(string category)
    {
      // Redirect to the Search action with the specified category
      return RedirectToAction("Search", new { category });
    }



    [Route("/advert/title-slug")]
    public IActionResult Detail(int id)
    {
      return View();
    }



  }
}
//make catehotu and stuff a link and add category to search