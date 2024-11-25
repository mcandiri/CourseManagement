using CourseManagement.Repositories.Abstract;
using CourseManagement.Services.Abstract;

namespace CourseManagement.Services.Concrete
{
    public class ReservationService(ICourseRepository courseRepository, IStudentRepository studentRepository) : IReservationService
    {
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IStudentRepository _studentRepository = studentRepository;

        public async Task<bool> RegisterStudentToCourseAsync(int courseId, int studentId)
        {
            // TODO: Implement the logic to register a student to a course.
            // 1. Check if the course capacity is available.
            // 2. Check if the student has already registered for this course.
            // 3. Update the available slots of the course.
            // 4. Add the StudentCourse record.
            return true; // Returning true as a placeholder
        }

        public async Task<bool> DeregisterStudentFromCourseAsync(int courseId, int studentId)
        {
            // TODO: Implement the logic to deregister a student from a course.
            // 1. Remove the StudentCourse record.
            // 2. Update the available slots of the course.
            return true; // Returning true as a placeholder
        }
    }
}
