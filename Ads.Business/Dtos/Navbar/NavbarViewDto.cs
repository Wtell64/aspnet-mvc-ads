using Ads.Entities.Concrete;

namespace Ads.Business.Dtos.Navbar
{
  public class NavbarViewDto
  {
    public IEnumerable<Ads.Entities.Concrete.Category> Categories { get; set; }
    public IEnumerable<Page> Pages { get; set; }
  }
}
