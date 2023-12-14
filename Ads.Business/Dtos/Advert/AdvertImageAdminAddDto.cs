using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Advert
{
  public class AdvertImageAdminAddDto
  {
    public int Id { get; set; }
    public List<IFormFile> Files { get; set; }
    public int AdvertId { get; set; }
  }
}
