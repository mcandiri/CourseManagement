using CourseManagement.Data;
using CourseManagement.Models;
using CourseManagement.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repositories.Concrete
{
  
    public class StudentRepository(AppDbContext context) : IStudentRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
    }

}
