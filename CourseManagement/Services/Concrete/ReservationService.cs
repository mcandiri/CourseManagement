using CourseManagement.Models;
using CourseManagement.Repositories.Abstract;
using CourseManagement.Services.Abstract;
using Microsoft.EntityFrameworkCore;


namespace CourseManagement.Services.Concrete
{
    public class ReservationService(ICourseRepository courseRepository, IStudentRepository studentRepository, IStudentCourseRepository studentCourseRepository) : IReservationService
    {
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly IStudentCourseRepository _studentCourseRepository = studentCourseRepository;


        // Burada parametreleri StudentCourseAddDto/Model ya da  gibi bir nesneyle getirebiliriz. Metodun dönüş tipini de StudentCourseDto/Model yaparak  daha esnek be bakımı kolay hale getirebiliriz.Nesne dönüşümlerini ise AutoMapper ile yapabiliriz. Ancak projenin genel yapısını değiştirmemek için bu yöntemi uygulamadım.
        public async Task<bool> RegisterStudentToCourseAsync(int courseId, int studentId) 
        {

            // courseId ile ilgili course bulunuyor.
            var course = await _courseRepository.GetByIdAsync(courseId);

            // studentId ile de ilgili student bulunuyor.
            var student = await _studentRepository.GetByIdAsync(studentId);

            var enrolledCoursesCount = await _studentCourseRepository.CountAsync(x => x.StudentId == studentId);
           // StudentCourseRepository'e CountAsync metodu eklenerek öğrencinin daha önce kaydolduğu derslerin toplam sayısı alınıyor.

            // Course'un boş kontenjanı varsa ve öğrencinin almış olduğu toplam kurs/ders sayısı bir öğrencinin alabileceği maksimum ders sayısından küçükse kayıt işlemi yapılıyor.
            if (course.AvailableSlots > 0 && enrolledCoursesCount < student.MaxCoursesAllowed)
            {
                course.AvailableSlots--;  // derse yeni bir kayıt yapıldığı için kontenjan 1 azaltılır.
                await _courseRepository.UpdateAsync(course);  // Course modelinde AvailableSlots sayısı değiştiği için Update ediliyor.

                // StudentCourse modelindeki propertyler için yeni kayıt işlemi StudentCourseRepositorydeki AddAsync metoduyla veritabanına ekleniyor.
                // Bu işlemi AutoMapper yöntemi ile daha kısa, temiz, bakımını kolay hale getirebiliriz. Özellikle karmaşık nesne dönüşümlerini çok daha basit hale getirebiliriz.Ancak projenin yapısını değiştirmek gerekeceğinden bu yöntemi denemedim.
                await _studentCourseRepository.AddAsync(new StudentCourse
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    EnrollmentDate = DateTime.UtcNow
                });                
            }
            else
            {
                return false;
            } 

            return true;

            // TODO: Implement the logic to register a student to a course.
            // 1. Check if the course capacity is available.
            // 2. Check if the student has already registered for this course.
            // 3. Update the available slots of the course.
            // 4. Add the StudentCourse record.
            // 5. Returning true as a placeholder.

        }

        public async Task<bool> DeregisterStudentFromCourseAsync(int courseId, int studentId)
        {

            // Öğrenci-Ders kaydını buluyoruz.
            var studentCourse = await _studentCourseRepository.FindAsync(sc => sc.CourseId == courseId && sc.StudentId == studentId);

            // Öğrencinin bu derste kaydı yoksa işlem devam etmiyor.
            if (studentCourse == null)
            {              
                return false;
            }

            // Kayıt varsa delete işlemi gerçekleşiyor.
            await _studentCourseRepository.DeleteAsync(studentCourse);

            // İlgili course'un bilgileri güncellenmek için bulunuyor.Kurs bulunuyorsa null değilse işlem yapılıyor.
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course != null)
            {
                // Kontenjan 1 artıyor.
                course.AvailableSlots++;
                // Dersin bilgileri güncelleniyor.
                await _courseRepository.UpdateAsync(course);
            }

            return true;

            // TODO: Implement the logic to deregister a student from a course.
            // 1. Remove the StudentCourse record.
            // 2. Update the available slots of the course.
            // 3. Returning true as a placeholder.
        }
    }
}
