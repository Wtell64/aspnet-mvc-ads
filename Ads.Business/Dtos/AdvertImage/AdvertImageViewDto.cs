using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.AdvertImage
{
  public class AdvertImageViewDto : IDto
  {
    public int Id { get; set; }
    public string ImagePath { get; set; }
    //Relationship
    public int AdvertId { get; set; }
  }
}
