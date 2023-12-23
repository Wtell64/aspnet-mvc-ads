namespace Ads.Business.Dtos.Admin
{
  public class HomeIndexDto
  {
    public List<PopularCategoriesPieDto> PieDtos { get; set; }
    public int UserCount { get; set; }
    public int TotalAdvertCount { get; set; }
    public int CityAvailablePercentage { get; set; }
    public int HighestAdvertPrice { get; set; }
    public string HighestAdvertTitle { get; set; }
  }

  public class PopularCategoriesPieDto
  {
    public string Color { get; set; }
    public int AdvertCount { get; set; }
    public string CategoryLabel { get; set; }
  }

  public class AdvertsByMonthAreaDto
  {
    public int[] AdvertCountPerMonth { get; set; } = new int[12];
  }
}
