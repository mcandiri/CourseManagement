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

        /// <summary>
        /// ensuring control of courses
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        private async Task<bool> ControlCourseAsync(int courseId)
        {
            var availableCourses = await _courseRepository.GetCoursesWithAvailableSlotsAsync().ConfigureAwait(false);
            if (availableCourses != null)
            {
                var isActive = availableCourses.Exists(c => c.Id == courseId);

                if (!isActive)
                {
                    return false;
                }
            }

            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ensuring student control
        /// </summary>
        /// <param name="courseId"> Kurs Id bilgisi </param>
        /// <param name="studentId">Ogrenci Id bilgisi/param>
        /// <returns>bool</returns>
        private async Task<bool> ControlStudentAsync(int courseId, int studentId)
        {
            var isRegistered = await _studentCourseRepository.FindAsync(sc => sc.StudentId == studentId &&
          sc.CourseId == courseId).ConfigureAwait(false);

            if (isRegistered != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<bool> RegisterStudentToCourseAsync(int courseId, int studentId)
        {
            // TODO: Implement the logic to register a student to a course.
            // 1. Check if the course capacity is available.
            // 2. Check if the student has already registered for this course.
            // 3. Update the available slots of the course.
            // 4. Add the StudentCourse record.

            #region Kurs Sorgulama

            bool isExists = await ControlCourseAsync(studentId).ConfigureAwait(false);
            if (!isExists) return false;

            #endregion

            #region Kursa Kayıtlı Öğreci Sorgulama

            var isRegistered = await ControlStudentAsync(courseId, studentId).ConfigureAwait(false);
            if (!isRegistered) return false;

            #endregion

            var studentCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now
            };

            var course = await _courseRepository.GetByIdAsync(courseId).ConfigureAwait(false);

            await _studentCourseRepository.AddAsync(studentCourse).ConfigureAwait(false);
            course.AvailableSlots -= 1;
            await _courseRepository.UpdateAsync(course).ConfigureAwait(false);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<bool> DeregisterStudentFromCourseAsync(int courseId, int studentId)
        {
            // TODO: Implement the logic to deregister a student from a course.
            // 1. Remove the StudentCourse record.
            // 2. Update the available slots of the course.

            var student = await _studentRepository.GetByIdAsync(studentId).ConfigureAwait(false);
            var course = await _courseRepository.GetByIdAsync(courseId).ConfigureAwait(false);

            if (student == null || course == null)
            {
                return false;
            }

            var isRegistered = await _studentCourseRepository.FindAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId).ConfigureAwait(false);
            if (isRegistered == null)
            {
                return false;
            }

            await _studentCourseRepository.DeleteAsync(isRegistered).ConfigureAwait(false);
            course.AvailableSlots += 1;
            await _courseRepository.UpdateAsync(course);

            return true; // Returning true as a placeholder
        }
    }
}
