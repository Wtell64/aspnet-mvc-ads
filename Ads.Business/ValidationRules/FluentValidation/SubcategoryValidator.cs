using Ads.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.ValidationRules.FluentValidation
{
	public class SubcategoryValidator : AbstractValidator<Subcategory>
	{
		public SubcategoryValidator()
		{
			RuleFor(n => n.Name).NotEmpty().WithMessage("Altkategori adı boş geçilemez");
			RuleFor(n => n.Name).MaximumLength(100).WithMessage("Name can be a maximum of 100 characters.");

		}
	}
}
