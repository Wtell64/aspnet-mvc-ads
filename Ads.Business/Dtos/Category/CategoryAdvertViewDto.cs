using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Category
{
  public class CategoryAdvertViewDto : IDto
  {
    public int Id { get; set; }
    public int CategoryId { get; set; }

    public int AdvertId { get; set; }
  }
}
