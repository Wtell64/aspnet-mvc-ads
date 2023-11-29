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
  public class AdvertImageValidator : AbstractValidator<AdvertImage>
  {
    public AdvertImageValidator()
    {
      RuleFor(t => t.ImagePath).NotEmpty().WithMessage("Image path cannot be empty.");
      RuleFor(ai => ai.AdvertId).GreaterThan(0).WithMessage("AdvertId must be greater than 0.");
      RuleFor(d => d.IsActive).NotNull().WithMessage("IsActive must not be null.");
    }
  }
}
