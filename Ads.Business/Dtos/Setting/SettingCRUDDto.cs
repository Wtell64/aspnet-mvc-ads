using Ads.Core.Entities.Abstract;
using Ads.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Setting
{
  public class SettingCRUDDto
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Ayar Adı alanı boş olamaz!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Ayar Değeri alanı boş olamaz!")]
    public string Value { get; set; }
    [Required(ErrorMessage = "Kullanıcı ID alanı boş olamaz!")]
    public int UserId { get; set; }
  }
}
