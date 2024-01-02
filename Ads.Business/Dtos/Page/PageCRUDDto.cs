using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Page
{
  public class PageCRUDDto:IDto
  {
    public int Id { get; set; }

    [Required(ErrorMessage ="Sayfa Başlığı alanı boş olamaz")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Sayfa İçeriği alanı boş olamaz")]
    public string Content { get; set; }

  }
}
