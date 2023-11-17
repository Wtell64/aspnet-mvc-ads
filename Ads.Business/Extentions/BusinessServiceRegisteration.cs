using Ads.Business.Abstract;
using Ads.Business.Concrete;
using Ads.Business.Mapping;
using Ads.Business.ValidationRules.FluentValidation;
using Ads.Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Extentions
{
  public static class BusinessServiceRegisteration
  {
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
      //services
      services.AddScoped<ICategoryService, CategoryManager>();

      //validators
      services.AddScoped<IValidator<Category>, CategoryValidator>();


      services.AddAutoMapper(typeof(MappingProfile));

      return services;
    }
  }
}
