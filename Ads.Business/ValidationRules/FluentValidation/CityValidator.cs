using Ads.Entities.Concrete;
using FluentValidation;

namespace Ads.Business.ValidationRules.FluentValidation
{
  public class CityValidator : AbstractValidator<City>
  {
    public CityValidator()
    {
      RuleFor(t => t.Name).NotEmpty().WithMessage("Şehir adı boş olamaz");
      RuleFor(t => t.Name).MaximumLength(70).WithMessage("En fazla 70 karakter girilebilir.");
    }
  }
}
