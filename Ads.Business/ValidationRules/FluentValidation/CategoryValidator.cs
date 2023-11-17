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
            RuleFor(t => t.Name).NotEmpty().WithMessage("Kategori ismi boş geçilemez");
        }
    }
}
