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
            // 1. Check if the course capacity is available.
            // 2. Check if the student has already registered for this course.
            // 3. Update the available slots of the course.
            // 4. Add the StudentCourse record.
            
            var course = await _courseRepository.GetByIdAsync(courseId); //kursu kontrol edip buldum
            if (course == null || course.AvailableSlots <= 0) //kurs bulunamadi veya musait degilse durumu
            {
                return false;
            }

            var student = await _studentRepository.GetByIdAsync(studentId); // ogrenciyi kontrol edip buldum
            if(student == null) //ogrenci var mi yok mu kontrolu yaptim 
            {
                return false;
            }

            var existingRegistration = await _studentCourseRepository.FindAsync(er => er.CourseId == courseId
            && er.StudentId == studentId); //ogrencinin kayitli olup olmadigini kontrol ediyorum
            if(existingRegistration != null)
            {
                //kayitli oldugu ders oldugu icin false dondurdum
                return false;
            }

            course.AvailableSlots -= 1; // kursun kapasitesini guncelledik (1 azalltim)
            await _courseRepository.UpdateAsync(course); //kursun kapasitesinin guncellenmesini bekledim

            var studentCourse = new StudentCourse  //StudentCourse un icine kayit verilerini ekledim
            {
                CourseId = courseId,
                StudentId = studentId,
                EnrollmentDate = DateTime.UtcNow
            };

            await _studentCourseRepository.AddAsync(studentCourse); // islemi tamamlamasini bekledim

            return true; // Returning true as a placeholder
        }

        public async Task<bool> DeregisterStudentFromCourseAsync(int courseId, int studentId)
        {
            // TODO: Implement the logic to deregister a student from a course.
            // 1. Remove the StudentCourse record.
            // 2. Update the available slots of the course.
            var course = await _courseRepository.GetByIdAsync(courseId); //Kursu kontrol edip buldum
           
            if(course == null)
            {
                return false;
            }

            var registration = await _studentCourseRepository.FindAsync
                (r => r.CourseId == courseId && r.StudentId == studentId); //ogrencinin kurs kaydini kontrol ettim 
           
            if (registration == null) 
            {
                return false;
            }

            await _studentCourseRepository.DeleteAsync(registration); //ogrenci-kurs iliskisini kaldirdim

            course.AvailableSlots += 1; //kursun kapasitesini guncelledim (1 arttirdim)
            await _courseRepository.UpdateAsync(course);// guncellemeleri almasi icin bekledim

            return true; // Returning true as a placeholder
        }
    }
}
