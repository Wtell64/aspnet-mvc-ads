using Ads.Core.Entities.Abstract;
using Ads.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.AdressDtos
{
  public class AddressCRUDDto
  {

    public int Id { get; set; }

    [Required(ErrorMessage = "Kullanıcı ID alanı boş olamaz !")]
    public int UserId { get; set; }
    public int DistrictId { get; set; }
    public int CityId { get; set; }
    [Required(ErrorMessage = "Posta Kodu alanı boş olamaz !")]
    public string PostCode { get; set; }
    public string Country { get; set; } = "Türkiye";
    [Required(ErrorMessage = "Detaylı adres alanı boş olamaz !")]
    public string DetailedAddress { get; set; }
  }
}
