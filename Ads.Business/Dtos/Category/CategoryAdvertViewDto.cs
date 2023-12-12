using Ads.Core.Entities.Abstract;

namespace Ads.Business.Dtos.Category
{

  public class SubcategoryAdvertViewDto : IDto
  {
    public int Id { get; set; }
    public int SubcategoryId { get; set; }


		public int AdvertId { get; set; }
	}
}
