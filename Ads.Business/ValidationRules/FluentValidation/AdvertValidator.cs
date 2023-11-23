using Ads.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.ValidationRules.FluentValidation
{
  public class AdvertValidator : AbstractValidator<Advert>
  {
       
  
    public AdvertValidator()
    {
      RuleFor(t => t.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
    
  }
}
}
