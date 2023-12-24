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
      RuleFor(n => n.Name)
    .NotEmpty().WithMessage("Kategori boş olamaz.")
    .MaximumLength(100).WithMessage("Kategori adı 100 karakterden uzun olamaz.");

      RuleFor(d => d.Description).NotEmpty().WithMessage("Açıklama adı boş olamaz.");

      RuleFor(d => d.Description).MaximumLength(300).WithMessage("Description cannot exceed 300 characters.");
      RuleFor(d => d.IconClass).NotEmpty().WithMessage("Kategori ikonu boş olamaz");

      RuleFor(c => c.IsActive).NotNull().WithMessage("IsActive must not be null");
    }
  }
}
