using Ads.Core.Utilities.Images;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Core.Extensions
{

  public static class CoreServiceRegisteration
  {
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {

      services.AddScoped<IImageProcessor, ImageProcessor>();
      return services;
    }


  }
}
