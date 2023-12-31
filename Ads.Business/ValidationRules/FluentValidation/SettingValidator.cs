﻿using Ads.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.ValidationRules.FluentValidation
{
  public class SettingValidator : AbstractValidator<Setting>
  {
    public SettingValidator() 
    {
      RuleFor(t=>t.User).NotEmpty().WithMessage("Can not be empty.");
      RuleFor(t => t.Name).NotEmpty().WithMessage("Can not be empty.");
      RuleFor(t => t.Value).NotEmpty().WithMessage("Can not be empty.");

    }
  }
}
