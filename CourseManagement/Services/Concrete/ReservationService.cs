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
            //Information about the course you want to register for is obtained.
            var course = await _courseRepository.GetByIdAsync(courseId);

            //Student information is obtained.
            var student = await _studentRepository.GetByIdAsync(studentId);

            //A DB query is made to check whether the student has previously registered for this course.
            var studentCourse = await _studentCourseRepository.FindAsync(x => x.StudentId == studentId && x.CourseId == courseId);

            //Null check is done according to course and student information and the course quota is checked and  if the student is not registered, we expect null.
            if (course == null || student == null || course.AvailableSlots == 0 || studentCourse != null)
            {
                return false;
            }

            //Course quota is reduced by 1 person.
            course.AvailableSlots -= 1;

            //Course information is updated.
            await _courseRepository.UpdateAsync(course);

            StudentCourse newStudentCourse = new()
            {
                CourseId = courseId,
                StudentId = studentId,
                EnrollmentDate = DateTime.Now
            };

            //The student is registered for the desired course.
            await _studentCourseRepository.AddAsync(newStudentCourse);

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
