using Ads.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.ValidationRules.FluentValidation
{
  public class CategoryValidator : AbstractValidator<Category>
  {
    public CategoryValidator()
    {
      RuleFor(n => n.Name).NotEmpty().MaximumLength(100).WithMessage("Category name cannot be empty.");

      RuleFor(d => d.Description).NotEmpty().MaximumLength(300).WithMessage("Description cannot be empty");

      RuleFor(d => d.Description).MaximumLength(300).WithMessage("Description cannot exceed 300 characters.");

      RuleFor(c => c.IsActive).NotNull().WithMessage("IsActive must not be null");
    }
  }
}
