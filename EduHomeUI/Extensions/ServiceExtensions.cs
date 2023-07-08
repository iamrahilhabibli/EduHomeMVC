// ServiceExtensions.cs

using EduHomeUI.Services.Concretes;
using EduHomeUI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EduHome.DataAccess.Contexts;

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
        }
    }
}
