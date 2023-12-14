using System.ComponentModel;

namespace Ads.Business.Dtos.City
{
  public class CityViewDto
  {
    public int Id { get; set; }

    [DisplayName("Şehir Adı")]
    public string Name { get; set; }
  }
}
