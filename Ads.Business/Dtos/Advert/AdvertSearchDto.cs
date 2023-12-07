using Ads.Core.Entities.Abstract;
using Ads.Entities.Concrete.Identity;
using Ads.Entities.Concrete;

namespace Ads.Business.Dtos.Advert
{
  public class AdvertSearchDto : IDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public int Price { get; set; }


    //Relationship
    public virtual ICollection<SubcategoryAdvert> CategoryAdverts { get; set; }
    public virtual ICollection<Ads.Entities.Concrete.AdvertImage> AdvertImages { get; set; }

    public virtual ICollection<Ads.Entities.Concrete.AdvertComment> AdvertComments { get; set; }
    public AppUser User { get; set; }
    public int UserId { get; set; }
  }
}
