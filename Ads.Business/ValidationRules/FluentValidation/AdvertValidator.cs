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
      RuleFor(t => t.Title).NotEmpty().WithMessage("Title cannot be empty.");

      RuleFor(d => d.Description).NotEmpty().WithMessage("Description cannot be empty.");

      RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");

      RuleFor(u => u.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");

      RuleFor(ca => ca.CategoryAdverts).NotEmpty().WithMessage("At least one category must be associated with the advert.");

      RuleFor(ai => ai.AdvertImages).NotEmpty().WithMessage("At least one image must be associated with the advert.");

      RuleFor(ac => ac.AdvertComments).NotEmpty().WithMessage("At least one comment must be associated with the advert.");
      RuleFor(d => d.IsActive).NotNull().WithMessage("IsActive must not be null.");
    }
  }
}
