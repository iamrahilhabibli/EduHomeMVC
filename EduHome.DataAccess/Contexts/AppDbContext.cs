using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EduHome.Core.Entities;
using EduHome.Core.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EduHome.DataAccess.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
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
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDetails> TeacherDetails { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDetails> EventsDetails { get; set; }  
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetails> BlogDetails { get; set; }
        public DbSet<UserReply> UserReplies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateModifiedInterceptor());
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.AddInterceptors(new IdGenerationInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
