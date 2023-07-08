using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>()
                .HasIndex(l => l.LanguageOption)
                .IsUnique(false);

            modelBuilder.Entity<SkillLevel>()
                .HasIndex(sl => sl.Skill)
                .IsUnique(false);

            modelBuilder.Entity<Assesment>()
                .HasIndex(a => a.AssesmentType)
                .IsUnique(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
