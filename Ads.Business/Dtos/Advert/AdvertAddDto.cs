using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Advert
{

  public class AdvertAddDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string AdType { get; set; }
    public string Description { get; set; }
    public List<int> SelectedSubategoryIds { get; set; }
    public decimal Price { get; set; }
    public bool IsNegotiable { get; set; }
    public List<IFormFile> Files { get; set; }
    public string ContactName { get; set; }
    public string ContactNumber { get; set; }
    public string ContactEmail { get; set; }
    public string ContactAddress { get; set; }
		public AdvertConditionEnum ConditionEnum { get; set; }
		//public string PaymentMethod { get; set; }
    public int ClickCount = 0;
    public bool AgreeToTerms { get; set; }

    public int UserId = 0;

    //public virtual ICollection<Ads.Entities.Concrete.AdvertImage> AdvertImages { get; set; }


  }
}
