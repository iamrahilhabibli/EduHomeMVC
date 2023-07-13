using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace EduHomeUI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(typeof(Program));

            services.AddPersistenceServices(configuration);
            services.AddEmailServices(configuration);

            services.AddScoped<ICourseCategoryService, CourseCategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IAssesmentService, AssesmentService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ISpeakerService, SpeakerService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INoticeService, NoticeService>();
            services.AddTransient<GoogleCaptchaService>();
            services.AddScoped<ISettingService, SettingService>();

        }

        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));

            });

            services.AddIdentity<AppUser, IdentityRole>(identityOptions =>
            {
                identityOptions.User.RequireUniqueEmail = true;

                identityOptions.Password.RequireNonAlphanumeric = true;
                identityOptions.Password.RequiredLength = 8;
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequireLowercase = true;
                identityOptions.Password.RequireUppercase = true;

                identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                identityOptions.Lockout.MaxFailedAccessAttempts = 3;
                identityOptions.Lockout.AllowedForNewUsers = true;

                identityOptions.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            {
                opt.TokenLifespan = TimeSpan.FromMinutes(15);
            });
        }

        public static void AddEmailServices(this IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSenderService, EmailSenderService>();

        }
        //public static void AddGoogleLogin(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddAuthentication()
        //        .AddGoogle("google", opt =>
        //        {
        //            var googleConfig = configuration.GetSection("Authentication:Google");
        //            opt.ClientId = googleConfig["ClientId"];
        //            opt.ClientSecret = googleConfig["ClientSecret"];
        //            opt.SignInScheme = IdentityConstants.ExternalScheme;
        //        });
        //}
       
    }
}
