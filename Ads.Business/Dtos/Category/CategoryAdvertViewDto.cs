using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Category
{
  public class SubcategoryAdvertViewDto : IDto
  {
    public int Id { get; set; }
    public int SubcategoryId { get; set; }

    public int AdvertId { get; set; }
  }
}
