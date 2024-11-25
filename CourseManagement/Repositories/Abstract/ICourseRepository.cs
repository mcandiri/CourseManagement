using CourseManagement.Models;
using System.Threading.Tasks;

namespace CourseManagement.Repositories.Abstract
{
    public interface ICourseRepository
    {
        // Get a course by its Id

        Task<Course> GetByIdAsync(int id);

        // Get all courses
        Task<List<Course>> GetAllAsync();

        // Add a new course
        Task AddAsync(Course course);

        // Update an existing course
        Task UpdateAsync(Course course);

        // Delete a course by its Id
        Task DeleteAsync(int id);

        // Get courses that have available slots
        Task<List<Course>> GetCoursesWithAvailableSlotsAsync();
    }
}
