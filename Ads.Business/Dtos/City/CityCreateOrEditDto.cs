﻿using System.ComponentModel;

namespace Ads.Business.Dtos.City
{
  public class CityCreateOrEditDto
  {
    public int Id { get; set; }

    [DisplayName("Şehir Adı")]
    public string Name { get; set; }
  }
}
