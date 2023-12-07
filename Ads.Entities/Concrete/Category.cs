namespace Ads.Entities.Concrete
{
	public class Category : BaseEntity
  {
   public string Name { get; set; }
   public string Description { get; set; }

   public string IconClass { get; set; }
   public virtual ICollection<Subcategory> Subcategories { get; set; }
   
  }
}
