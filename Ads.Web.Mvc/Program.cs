using Ads.Business.Extentions;
using Ads.Dal.Concrete.EntityFramework.Context;
using Ads.Dal.Extentions;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddBusinessServices();

var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)   //loglamaya nerden baslicam
.Enrich.FromLogContext()
.CreateLogger();

builder.Logging.ClearProviders(); //loglamanin sahibi degilsin
builder.Logging.AddSerilog(logger); //bu isi logger yapicak
																		// builder.Logging.AddConsole();

#region Identity
builder.Services.AddSession();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
})
		.AddRoleManager<RoleManager<AppRole>>()
		//.AddErrorDescriber<CustomIdentityErrorDescriber>()
		.AddEntityFrameworkStores<DataContext>()
		.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
	config.LoginPath = new PathString("/Admin/Auth/Login");
	config.LogoutPath = new PathString("/Admin/Auth/Logout");
	config.Cookie = new CookieBuilder
	{
		Name = "AspNetMvcAds",
		HttpOnly = true,
		SameSite = SameSiteMode.Strict,
		SecurePolicy = CookieSecurePolicy.SameAsRequest //Always 
	};
	config.SlidingExpiration = true;
	config.ExpireTimeSpan = TimeSpan.FromDays(7);
	config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied"); // Yetkisiz biri girmeye çalýþtýðýnda çalýþacak kýsým.
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
app.UseSession(); // identity

app.UseRouting();

app.UseAuthentication();// identity
app.UseAuthorization();


//app.UseEndpoints(endpoints =>
//{
//	endpoints.MapControllerRoute(
//			name: "admin",
//			pattern: "admin/{controller=Home}/{action=Index}/{id?}",
//			defaults: new { area = "Admin" }
//	);
//	endpoints.MapControllerRoute(
//			name: "default",
//			pattern: "{controller=Home}/{action=Index}/{id?}"
//	);
//});


app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
	name: "Admin",
	areaName: "Admin",
	pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
	);
	endpoints.MapDefaultControllerRoute();
});

app.Run();
