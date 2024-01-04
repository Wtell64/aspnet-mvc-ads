using Ads.Business.Extentions;
using Ads.Core.Extensions;
using Ads.Dal.Extentions;
using Ads.Web.Mvc.Middlewares;
using Ads.Web.Mvc.Sinks;
using NToastNotify;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddCoreServices();

builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
{
  ProgressBar = false,
  PositionClass = ToastPositions.BottomCenter
});
builder.Services.AddMvc().AddNToastNotifyNoty(new NotyOptions
{
  ProgressBar = true,
  Timeout = 5000,
  Theme = "mint"
});

var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
.WriteTo.CustomSink()
.Enrich.FromLogContext()//loglamaya nerden baslicam
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


  options.LoginPath = new PathString("/Auth/Login"); // Kullanýcýlar üye olmadan kullanýcý sayfalarýna gitmeye kalkarsa yönlendireceði sayfa.
  options.AccessDeniedPath = new PathString("/Home/Index");


	options.Cookie = cookieBuilder;
  options.ExpireTimeSpan = TimeSpan.FromDays(7); // Cookie saklama ömrü.
  options.SlidingExpiration = true; // Kullanýcý cookie ömrü bitmeden giriþ yaparsa üzerine eklemesini saðlar.

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

app.UseMiddleware(typeof(ExceptionHandlingMiddleware));


app.UseRouting();

app.UseAuthentication();// identity
app.UseAuthorization();

app.UseNToastNotify();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
