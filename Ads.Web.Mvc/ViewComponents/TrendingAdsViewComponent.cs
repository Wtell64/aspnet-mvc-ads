using Ads.Business.Abstract;
using Ads.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Web.Mvc.ViewComponents
{
	public class TrendingAdsViewComponent : ViewComponent
	{
		private readonly IAdvertService _advertService;

		public TrendingAdsViewComponent(IAdvertService advertService)
		{
			_advertService = advertService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var adverts = _advertService.GetList<Advert>(null,null, "SubcategoryAdverts.Subcategory,AdvertImages");
			var trendingAdverts =  adverts.Data.OrderByDescending(a => a.ClickCount).Take(6).ToList();
			return View("TrendingAds", trendingAdverts);
		}
	}
}
