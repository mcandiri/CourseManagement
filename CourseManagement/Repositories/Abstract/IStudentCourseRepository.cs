using CourseManagement.Models;
using System.Linq.Expressions;

namespace CourseManagement.Repositories.Abstract
{
    public interface IStudentCourseRepository 
    {
        Task<StudentCourse?> FindAsync(Expression<Func<StudentCourse, bool>> predicate);
    }
}
