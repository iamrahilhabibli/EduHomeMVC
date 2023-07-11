using EduHome.Core.Entities;
using EduHomeUI.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddCustomServices(builder.Configuration);
builder.Services.Configure<ReCAPTCHASettings>(builder.Configuration.GetSection("GooglereCAPTCHA"));
builder.Services.AddHttpClient<ICaptchaValidator,GoogleReCaptchaValidator>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<AssesmentViewModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BlogViewModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CourseCategoryViewModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CourseViewModelValidator>();

builder.Services.AddAuthentication()
    .AddGoogle("google", opt =>
    {
        var serviceProvider = builder.Services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();
        var googleAuth = configuration.GetSection("Authentication:Google");
        opt.ClientId = googleAuth["ClientId"];
        opt.ClientSecret = googleAuth["ClientSecret"];
        opt.SignInScheme = IdentityConstants.ExternalScheme;
    });

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

