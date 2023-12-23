using Ads.Business.ValidationRules.CustomValidations.Localizations;
using Ads.Dal.Concrete.EntityFramework.Context;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Ads.Business.Extentions
{
	public static class StartupExtensions
	{
		public static void AddIdentityWithExtensions(this IServiceCollection services)
		{

			services.Configure<DataProtectionTokenProviderOptions>(options =>
			{
				options.TokenLifespan = TimeSpan.FromHours(2);
			});// Şifremi unuttum işlemleri için verdiğim tokenın yaşam süresi.

			services.Configure<SecurityStampValidatorOptions>(options =>
			{
				options.ValidationInterval = TimeSpan.FromHours(1);
			}); // identity her 30 dakika da bir securityStamp kısmını güncelleyip karşılaştırıyor. Kullanıcı eğer çıkış yapmadan çıkarsa(tarayıcıyı direk kapatırsa) ve o sırada da mobilden birisi girip şifresini vs değiştirirse şifreler eşleşmediğinden hataya düşecek. Onu engellemek adına yazıldı.

			services.AddIdentity<AppUser, AppRole>(options =>
			{
				options.User.RequireUniqueEmail = true; // tek bir tane email olsun.

				options.Password.RequiredLength = 6; // En az 6 karakter olsun demek.
				options.Password.RequireNonAlphanumeric = false; // Alfanümerik olması zorunlu. Yani hem harf hem sayı içermeli.
				options.Password.RequireLowercase = false; // Küçük harf olmak zorunlu.
				options.Password.RequireUppercase = false; // Büyük harf olmak zorunlu.
				options.Password.RequireDigit = false; // Sayı olmak zorunlu.

				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Yanlış giriş yaptığında ki kitleme süresi
				options.Lockout.MaxFailedAccessAttempts = 3; // 3 kere yanlış girerse bir kişi yukarı da ki dakika kadar kitlenecektir.

				options.SignIn.RequireConfirmedEmail = true; // Uygulamaya kayıt olan bir kullanıcı email onaylaması gerekir.

			}).AddErrorDescriber<LocalizationIdentityErrorDescriber>()
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<DataContext>();

		}
	}
}
