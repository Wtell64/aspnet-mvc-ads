using Ads.Core.Entities.Abstract;

namespace Ads.Entities.Concrete
{
  public class District : BaseEntity, IEntity
  {
    public string Name { get; set; }
    //Relationships
    public City City { get; set; }
    public int CityId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; }
  }
}
