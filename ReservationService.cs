using CourseManagement.Models;
using CourseManagement.Repositories.Abstract;
using CourseManagement.Services.Abstract;

namespace CourseManagement.Services.Concrete
{
    public class ReservationService(ICourseRepository courseRepository, IStudentRepository studentRepository, IStudentCourseRepository studentCourseRepository) : IReservationService
    {
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly IStudentCourseRepository _studentCourseRepository = studentCourseRepository;

        public async Task<bool> RegisterStudentToCourseAsync(int courseId, int studentId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null || course.AvailableSlots <= 0)
            {
                Console.WriteLine($"Course with ID {courseId} is not available or full.");
                return false; // Course does not exist or is full
            }

            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
            {
                Console.WriteLine($"Student with ID {studentId} does not exist.");
                return false; // Student does not exist
            }

            var existingRegistration = await _studentCourseRepository.FindAsync(sc => sc.CourseId == courseId && sc.StudentId == studentId);
            if (existingRegistration != null)
            {
                Console.WriteLine($"Student with ID {studentId} is already registered for Course ID {courseId}.");
                return false; // Already registered
            }

            course.AvailableSlots--;
            await _courseRepository.UpdateAsync(course);

            var studentCourse = new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId
            };

            await _studentCourseRepository.AddAsync(studentCourse);
            Console.WriteLine($"Student with ID {studentId} successfully registered for Course ID {courseId}.");
            return true; // Registration successful
        }


        public async Task<bool> DeregisterStudentFromCourseAsync(int courseId, int studentId)
        {
            // 1. Find the StudentCourse record.
            var studentCourse = await _studentCourseRepository.FindAsync(sc => sc.CourseId == courseId && sc.StudentId == studentId);
            if (studentCourse == null)
            {
                return false; // Registration not found
            }

            // 2. Remove the StudentCourse record.
            await _studentCourseRepository.DeleteAsync(studentCourse);

            // 3. Update the available slots of the course.
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course != null)
            {
                course.AvailableSlots++;
                await _courseRepository.UpdateAsync(course);
            }

            return true; // Deregistration successful
        }
    }
}
