using Ads.Business.Extentions;
using Ads.Core.Extensions;
using Ads.Dal.Extentions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddCoreServices();

var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)   //loglamaya nerden baslicam
.Enrich.FromLogContext()
.CreateLogger();

builder.Logging.ClearProviders(); //loglamanin sahibi degilsin
builder.Logging.AddSerilog(logger); //bu isi logger yapicak
																		// builder.Logging.AddConsole();

#region Identity

builder.Services.AddIdentityWithExtensions();

builder.Services.ConfigureApplicationCookie(options =>
{

	var cookieBuilder = new CookieBuilder();
	cookieBuilder.Name = "AspNetMvcAds.Web";

	options.LoginPath = new PathString("/Home/Signin"); // Kullan�c�lar �ye olmadan kullan�c� sayfalar�na gitmeye kalkarsa y�nlendirece�i sayfa.

	options.Cookie = cookieBuilder;
	options.ExpireTimeSpan = TimeSpan.FromDays(7); // Cookie saklama �mr�.
	options.SlidingExpiration = true; // Kullan�c� cookie �mr� bitmeden giri� yaparsa �zerine eklemesini sa�lar.

});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();// identity
app.UseAuthorization();

app.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
