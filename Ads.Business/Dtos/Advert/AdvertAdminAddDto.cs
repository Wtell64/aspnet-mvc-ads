using Ads.Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Advert
{
  public class AdvertAdminAddDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public List<int> SelectedSubategoryIds { get; set; }

    public string Description { get; set; }
    public AdvertConditionEnum ConditionEnum { get; set; }
    public decimal Price { get; set; }

    public int ClickCount { get; set; }

    public int UserId { get; set; }
  }
}
