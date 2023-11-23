using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.AdvertComment
{
  public class AdvertCommentViewDto : IDto
  {
    public string Comment { get; set; }

    //Relationships

    public int AdvertId { get; set; }
    public int UserId { get; set; }
  }
}
