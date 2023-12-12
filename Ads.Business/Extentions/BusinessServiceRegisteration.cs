using Ads.Business.Abstract;
using Ads.Business.Abstract.Identity;
using Ads.Business.Concrete;
using Ads.Business.Concrete.Identity;
using Ads.Business.Dtos.Users;
using Ads.Business.Mapping;
using Ads.Business.ValidationRules.FluentValidation;
using Ads.Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ads.Business.Extentions
{
	public static class BusinessServiceRegisteration
	{
		public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
		{
			//services
			services.AddScoped<ICategoryService, CategoryManager>();
			services.AddScoped<IAdvertService, AdvertManager>();
			services.AddScoped<IAdvertCommentService, AdvertCommentManager>();
			services.AddScoped<IAdvertImageService, AdvertImageManager>();
			services.AddScoped<IPageService, PageManager>();
			services.AddScoped<IAddressService, AddressManager>();
			services.AddScoped<ICityService, CityManager>();
			services.AddScoped<IDistrictService, DistrictManager>();
			services.AddScoped<ISubcategoryService, SubcategoryManager>();
			services.AddScoped<ISettingService, SettingManager>();


			services.AddScoped<IEmailService, EmailService>();
			services.Configure<EmailSenderDto>(configuration.GetSection("EmailSenderDto"));

			//services.AddScoped<IEmailSender, SmtpEmailSender>
			//(i => new SmtpEmailSender(
			//			configuration["EmailSender:Host"],
			//			configuration.GetValue<int>("EmailSender:Port"),
			//			configuration.GetValue<bool>("EmailSender:EnableSSL"),
			//			configuration["EmailSender:Username"],
			//			configuration["EmailSender:Password"]));


			//validators
			services.AddScoped<IValidator<Category>, CategoryValidator>();
			services.AddScoped<IValidator<Advert>, AdvertValidator>();
			services.AddScoped<IValidator<AdvertComment>, AdvertCommentValidator>();
			services.AddScoped<IValidator<AdvertImage>, AdvertImageValidator>();
			services.AddScoped<IValidator<Page>, PageValidator>();
			services.AddScoped<IValidator<Address>, AddressValidator>();
			services.AddScoped<IValidator<City>, CityValidator>();
			services.AddScoped<IValidator<District>, DistrictValidator>();
			services.AddScoped<IValidator<Subcategory>, SubcategoryValidator>();
			services.AddScoped<IValidator<Setting>, SettingValidator>();
			services.AddAutoMapper(typeof(MappingProfile));

			return services;
		}
	}
}
