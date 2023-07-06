using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHome.DataAccess.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Course> courses { get; set; }
        public DbSet<CourseDetails> courseDetails { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Assesment> Assesments { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<CourseCategory> courseCategories { get; set; }
    }
}
