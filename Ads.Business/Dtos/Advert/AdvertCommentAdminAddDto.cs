using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Advert
{
  public class AdvertCommentAdminAddDto
  {
    public int? Id { get; set; }
    public string Comment { get; set; }

    public int StarCount { get; set; }

    //Relationships
    public int UserId { get; set; }
    public int AdvertId { get; set; }
  }
}
