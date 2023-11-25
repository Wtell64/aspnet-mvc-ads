using Ads.Entities.Concrete;
using FluentValidation;

namespace Ads.Business.ValidationRules.FluentValidation
{
  public class PageValidator : AbstractValidator<Page>
  {
    public PageValidator()
    {
      RuleFor(t => t.Title).NotEmpty().WithMessage("Başlık boş olamaz");
      RuleFor(t => t.Content).NotEmpty().WithMessage("İçerik boş olamaz");
    }
  }
}
