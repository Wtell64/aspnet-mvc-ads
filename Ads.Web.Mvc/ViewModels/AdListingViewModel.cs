using Ads.Business.Dtos.Advert;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Ads.Business.Dtos.Advert.AdvertAddDto;

namespace Ads.Web.Mvc.ViewModels
{
  public class AdListingViewModel
  {
    //public List<SelectListItem> Categories { get; set; }
    public AdvertAddDto AdvertAddDto { get; set; }
  }
}
