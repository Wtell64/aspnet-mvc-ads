namespace Ads.Entities.Concrete
{
	public class SubcategoryAdvert : BaseEntity
  {
  public int SubcategoryId { get; set; }

  public int AdvertId { get; set; }

  //Relationship
  public Advert Advert { get; set; }
  public Subcategory Subcategory { get; set; }
  }
}
