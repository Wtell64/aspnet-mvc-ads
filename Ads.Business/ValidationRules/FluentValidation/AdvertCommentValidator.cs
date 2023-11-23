using Ads.Entities.Concrete;
using FluentValidation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.ValidationRules.FluentValidation
{
  public class AdvertCommentValidator : AbstractValidator<AdvertComment>
  {
    public AdvertCommentValidator()
    {
      RuleFor(t => t.Comment).NotEmpty().WithMessage("Yorum boş geçilemez");
    }
  }
}
