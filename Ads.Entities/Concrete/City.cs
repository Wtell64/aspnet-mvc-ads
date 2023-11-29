using Ads.Core.Entities.Abstract;

namespace Ads.Entities.Concrete
{
  public class City : BaseEntity, IEntity
  {
    public string Name { get; set; }

    public virtual ICollection<District> Districts { get; set; }

    //Relationships
    public virtual ICollection<Address> Adresses { get; set; }
  }
}
