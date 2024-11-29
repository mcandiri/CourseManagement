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
			// 1. Kursu ve öğrenciyi kontrol et
			var course = await _courseRepository.GetByIdAsync(courseId);
			var student = await _studentRepository.GetByIdAsync(studentId);

			if (course == null || student == null)
				return false;

			// 2. Kurs kapasitesi kontrolü
			if (course.AvailableSlots <= 0)
				return false;

			// 3. Öğrencinin daha önce bu kursa kayıtlı olup olmadığını kontrol et
			var existingRegistration = await _studentCourseRepository.FindAsync(
				sc => sc.CourseId == courseId && sc.StudentId == studentId);

			if (existingRegistration != null)
				return false;

			// 4. Yeni StudentCourse kaydı oluştur
			var studentCourse = new StudentCourse
			{
				CourseId = courseId,
				StudentId = studentId,
				EnrollmentDate = DateTime.UtcNow
			};

			await _studentCourseRepository.AddAsync(studentCourse);

			return true;
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
