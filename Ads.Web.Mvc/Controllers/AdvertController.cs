using Ads.Business.Abstract;
using Ads.Business.Dtos.Advert;
using Ads.Business.Dtos.AdvertComment;
using Ads.Business.Dtos.AdvertImage;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Search(string query, int page)
    {
      return View();
    }
    [Route("/advert/title-slug")]
    public IActionResult Detail(int id)
    {
      return View();
    }


    public IActionResult Deneme()
    {
      var deneme = new Advert() { Title = "Krem Reklami", Description = "Bu bir kremdir" };
      _advertService.Add(deneme);
      return View(); 
    
    }
    public IActionResult Index()
    
    {
      //var deneme = new AdvertViewDto() { Title = "Krem Reklami", Description = "Bu bir kremdir", UserId = 1 };
      //_advertService.Add(deneme);
      //_advertService.Save();

      //var deneme = new AdvertImageViewDto() { AdvertId = 3, ImagePath = "deneme" };
      //_advertImageService.Add(deneme);
      //_advertImageService.Save();

      //var deneme = new AdvertCommentViewDto() { AdvertId = 3, Comment = "deneme2", UserId = 1 };
      //_advertCommentService.Add(deneme);
      //_advertCommentService.Save();

      //_advertCommentService.DeleteById(2);
      //_advertCommentService.Save();

      _advertService.DeleteById(3);
      _advertService.Save();
      return View();
    }
  }
}
