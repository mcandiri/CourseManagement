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
            if (course == null || course.AvailableSlots <= 0) return false;

            var studentCourse = new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId
            };

            await _studentCourseRepository.AddAsync(studentCourse);
            course.AvailableSlots--;
            await _courseRepository.UpdateAsync(course);

            return true;
        }

        public async Task<bool> DeregisterStudentFromCourseAsync(int courseId, int studentId)
        {
         var studentCourse = await _studentCourseRepository.FindAsync(
        sc => sc.CourseId == courseId && sc.StudentId == studentId);

            if (studentCourse == null) return false; 

                
                await _studentCourseRepository.DeleteAsync(studentCourse);

                var course = await _courseRepository.GetByIdAsync(courseId);
                if (course != null)
                {
                    course.AvailableSlots++;
                    await _courseRepository.UpdateAsync(course);
                }

                return true;

        }
    }
}
