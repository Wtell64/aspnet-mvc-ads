namespace Ads.Business.Dtos.Admin
{
  public class HomeIndexDto
  {
    public List<PieDto> PieDtos { get; set; }
  }

  public class PieDto
  {
    public string Color { get; set; }
    public int AdvertCount { get; set; }
    public string CategoryLabel { get; set; }
  }
}
