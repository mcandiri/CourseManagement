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
            // 1. Check if the course capacity is available.+
            // 2. Check if the student has already registered for this course.
            // 3. Update the available slots of the course.
            // 4. Add the StudentCourse record.

      
            var availableCourses = await _courseRepository.GetCoursesWithAvailableSlotsAsync();
            var isActive = availableCourses.Any(c => c.Id == courseId);

            if (!isActive)
            {
                return false;
            }

            var isRegistered = await _studentCourseRepository.FindAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);

            if (isRegistered != null)
            {
                return false;
            }


            var studentCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now
            };
            var course = await _courseRepository.GetByIdAsync(courseId);
            await _studentCourseRepository.AddAsync(studentCourse);
            course.AvailableSlots -= 1;
            await _courseRepository.UpdateAsync(course);
            return true; // Returning true as a placeholder
        }

        public async Task<bool> DeregisterStudentFromCourseAsync(int courseId, int studentId)
        {
            // TODO: Implement the logic to deregister a student from a course.
            // 1. Remove the StudentCourse record.
            // 2. Update the available slots of the course.

            var student = await _studentRepository.GetByIdAsync(studentId);
            var course = await _courseRepository.GetByIdAsync(courseId);

            if(student == null ||  course == null)
            {
                return false;
            }

            var isRegistered = await _studentCourseRepository.FindAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            if(isRegistered ==null)
            {
                return false;
            }

            _studentCourseRepository.DeleteAsync(isRegistered);
            course.AvailableSlots += 1;
            await _courseRepository.UpdateAsync(course);

            return true; // Returning true as a placeholder
        }
    }
}
