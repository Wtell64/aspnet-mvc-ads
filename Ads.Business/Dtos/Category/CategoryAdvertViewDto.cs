using Ads.Core.Entities.Abstract;

namespace Ads.Business.Dtos.Category
{
	public class CategoryAdvertViewDto : IDto
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }

		public int AdvertId { get; set; }
	}
}
