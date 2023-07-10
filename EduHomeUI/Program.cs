using EduHome.Core.Entities;
using EduHomeUI.Extensions;
using EmailService;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddCustomServices(builder.Configuration);
builder.Services.Configure<ReCAPTCHASettings>(builder.Configuration.GetSection("GooglereCAPTCHA"));
builder.Services.AddHttpClient<ICaptchaValidator,GoogleReCaptchaValidator>();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
);
app.Run();

