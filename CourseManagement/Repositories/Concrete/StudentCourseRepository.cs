using CourseManagement.Data;
using CourseManagement.Models;
using CourseManagement.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseManagement.Repositories.Concrete
{
    public class StudentCourseRepository(AppDbContext context) : IStudentCourseRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<StudentCourse?> FindAsync(Expression<Func<StudentCourse, bool>> predicate)
        {
            return await _context.Set<StudentCourse>().FirstOrDefaultAsync(predicate);
        }

        public async Task AddAsync(StudentCourse studentCourse)
        {
            await _context.Set<StudentCourse>().AddAsync(studentCourse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(StudentCourse studentCourse)
        {
            _context.Set<StudentCourse>().Remove(studentCourse);
            await _context.SaveChangesAsync();
        }
    }
}
