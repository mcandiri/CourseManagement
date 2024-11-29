using CourseManagement.Models;
using System.Linq.Expressions;

namespace CourseManagement.Repositories.Abstract
{
    public interface IStudentCourseRepository 
    {
        Task<StudentCourse?> FindAsync(Expression<Func<StudentCourse, bool>> predicate);
        Task AddAsync(StudentCourse studentCourse);
        Task DeleteAsync(StudentCourse studentCourse);

        Task<int> CountAsync(Expression<Func<StudentCourse, bool>> predicate);
    }
}
