using CourseManagement.Models;

namespace CourseManagement.Repositories.Abstract
{
    public interface IStudentRepository
    {
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
        Task AddAsync(Student student);
    }
}
