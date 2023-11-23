using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Advert
{
  public class AdvertViewDto : IDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public int UserId { get; set; }
  }
}
