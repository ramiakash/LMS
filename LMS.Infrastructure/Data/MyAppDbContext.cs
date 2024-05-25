using Microsoft.EntityFrameworkCore;
using LMS.Domain.Entities;

namespace LMS.Infrastructure.Data
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        { }

		public DbSet<User> Users { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<UserCourse> userCourses { get; set; }
 		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserCourse>()
				.HasKey(cs => new { cs.CourseId, cs.UserId });

			modelBuilder.Entity<UserCourse>()
				.HasOne(cs => cs.Course)
				.WithMany(c => c.UserCourses)
				.HasForeignKey(cs => cs.CourseId);

			modelBuilder.Entity<UserCourse>()
				.HasOne(cs => cs.User)
				.WithMany(u => u.UserCourses)
				.HasForeignKey(cs => cs.UserId);
			 
		}
	}
}
