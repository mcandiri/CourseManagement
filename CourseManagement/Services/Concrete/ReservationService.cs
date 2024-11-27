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
            // TODO: Implement the logic to register a student to a course.

            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null)
            {
                return false;
            }
            // 1. Check if the course capacity is available.
            if (course.AvailableSlots <= 0)
            {
                return false;
            }
            // 2. Check if the student has already registered for this course.
            var studentCourse = await _studentCourseRepository.FindAsync(x => x.CourseId == courseId && x.StudentId == studentId);
            if (studentCourse != null)
            {
                return false;
            }
            var newStudentForCourse = new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId,
                EnrollmentDate = DateTime.Now
            };
            // 3. Update the available slots of the course.
            course.AvailableSlots -= 1;
            // 4. Add the StudentCourse record.
            await _studentCourseRepository.AddAsync(newStudentForCourse);
            await _courseRepository.UpdateAsync(course);
            return true;  // Returning true as a placeholder
        }

        public async Task<bool> DeregisterStudentFromCourseAsync(int courseId, int studentId)
        {
            // TODO: Implement the logic to deregister a student from a course.

            var studentCourse = await _studentCourseRepository.FindAsync(sc => sc.CourseId == courseId && sc.StudentId == studentId);
            if (studentCourse == null)
            {
                return false;
            }
            // 1. Remove the StudentCourse record.
            await _studentCourseRepository.DeleteAsync(studentCourse);

            // 2. Update the available slots of the course.
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course != null)
            {
                course.AvailableSlots += 1;
                await _courseRepository.UpdateAsync(course);
            }
            return true; // Returning true as a placeholder
        }
    }
}
