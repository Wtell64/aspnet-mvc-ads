using Ads.Dal.Abstract;
using Ads.Dal.Concrete.EntityFramework;
using Ads.Dal.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ads.Dal.Extentions
{



  public static class DalServiceRegisteration
  {
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {

      services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DBConStr-MURATCAN")));

      services.AddScoped<ICategoryDal, EFCategoryDal>();
      services.AddScoped<IAdvertDal, EfAdvertDal>();
      services.AddScoped<IAdvertCommentDal, EfAdvertCommentDal>();
      services.AddScoped<IAdvertImageDal, EfAdvertImageDal>();
      services.AddScoped<IPageDal, EfPageDal>();
      services.AddScoped<IAddressDal, EfAddressDal>();
      services.AddScoped<ICityDal, EfCityDal>();
      services.AddScoped<IDistrictDal, EfDisctrictDal>();
      services.AddScoped<ISubcategoryAdvertDal, EfSubcategoryAdvertDal>();
      services.AddScoped<ISubcategoryDal, EfSubcategoryDal>();
      services.AddScoped<ISettingDal, EfSettingDal>();


			return services;
		}
	}
}
