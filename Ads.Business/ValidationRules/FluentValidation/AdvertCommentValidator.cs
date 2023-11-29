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
      RuleFor(t => t.Comment).NotEmpty().WithMessage("Comment cannot be empty.");
      RuleFor(ac => ac.AdvertId).GreaterThan(0).WithMessage("AdvertId must be greater than 0.");
      RuleFor(ac => ac.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
      RuleFor(d => d.IsActive).NotNull().WithMessage("IsActive must not be null.");
    }
  }
}
