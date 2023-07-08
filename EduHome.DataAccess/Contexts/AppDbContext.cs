using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EduHome.Core.Entities;
using EduHome.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EduHome.DataAccess.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetails> CourseDetails { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Assesment> Assesments { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CourseDetailsAssesment> CourseDetailsAssesments { get; set; }
        public DbSet<CourseDetailsSkillLevel> CourseDetailsSkillLevels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateModifiedInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
