using Ads.Entities.Concrete;
using FluentValidation;

namespace Ads.Business.ValidationRules.FluentValidation
{
  public class DistrictValidator : AbstractValidator<District>
  {
    public DistrictValidator()
    {
      RuleFor(t => t.Name).NotEmpty().WithMessage("İlçe adı boş olamaz");
      RuleFor(t => t.Name).MaximumLength(70).WithMessage("En fazla 70 karakter girilebilir.");
    }
  }
}
