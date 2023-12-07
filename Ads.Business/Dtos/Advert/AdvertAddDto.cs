using Ads.Entities.Concrete;
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
    public List<int> SelectedCategoryIds { get; set; }
    public decimal Price { get; set; }
    public bool IsNegotiable { get; set; }
    public List<IFormFile> Files { get; set; }
    public string ContactName { get; set; }
    public string ContactNumber { get; set; }
    public string ContactEmail { get; set; }
    public string ContactAddress { get; set; }
    public string FeaturedAdOption { get; set; }
    //public string PaymentMethod { get; set; }
    
    public bool AgreeToTerms { get; set; }

    //public virtual ICollection<Ads.Entities.Concrete.AdvertImage> AdvertImages { get; set; }


  }
}
