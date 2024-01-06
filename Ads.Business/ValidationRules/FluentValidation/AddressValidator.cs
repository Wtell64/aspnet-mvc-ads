using Ads.Entities.Concrete;
using FluentValidation;

namespace Ads.Business.ValidationRules.FluentValidation
{
  public class AddressValidator : AbstractValidator<Address>
  {
    public AddressValidator()
    {
      RuleFor(t => t.Country).NotEmpty().WithMessage("Ülke boş olamaz");
      RuleFor(t => t.Country).MaximumLength(70).WithMessage("En fazla 70 karakter girilebilir.");

      RuleFor(t => t.DetailedAddress).MaximumLength(300).WithMessage("En fazla 300 karakter girilebilir.").NotEmpty().WithMessage("Detaylı Adres boş olamaz.");

      RuleFor(t => t.PostCode).NotEmpty().WithMessage("Posta kodu boş olamaz");
      RuleFor(t => t.PostCode).MaximumLength(20).WithMessage("En fazla 20 karakter girilebilir.");
    }
  }
}
