using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
             .HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
