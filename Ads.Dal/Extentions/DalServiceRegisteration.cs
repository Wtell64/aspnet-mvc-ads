using Ads.Dal.Abstract;
using Ads.Dal.Concrete.EntityFramework;
using Ads.Dal.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Dal.Extentions
{
  public static class DalServiceRegisteration
  {
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DBConStr")));

      services.AddScoped<ICategoryDal, EFCategoryDal>();

      services.AddScoped<IAdvertDal, EfAdvertDal>();
      services.AddScoped<IAdvertCommentDal, EfAdvertCommentDal>();
      services.AddScoped<IAdvertImageDal, EfAdvertImageDal>();

      return services;
    }
  }
}
