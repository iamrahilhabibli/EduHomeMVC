using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Program));
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("Default"));
            });

            services.AddScoped<ICourseCategoryService, CourseCategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IAssesmentService, AssesmentService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ISpeakerService, SpeakerService>();

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
                 
        }
    }
}
