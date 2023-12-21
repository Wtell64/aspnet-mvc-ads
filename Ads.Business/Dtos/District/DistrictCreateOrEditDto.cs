using System.ComponentModel;

namespace Ads.Business.Dtos.District
{
  public class DistrictCreateOrEditDto
  {
    public int Id { get; set; }

    [DisplayName("İlçe Adı")]
    public string Name { get; set; }

    public int CityId { get; set; }
  }
}
