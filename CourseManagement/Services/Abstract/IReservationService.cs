using CourseManagement.Models;

namespace CourseManagement.Services.Abstract
{
    public interface IReservationService
    {

        /// <summary>
        /// Adds the student to the selected course.
        /// </summary>
        /// <param name="courseId">Takes the course Id parameter.</param>
        /// <param name="studentId">Takes the Student Id parameter.</param>
        /// <returns>Returns a value of type true or false</returns>
        Task<bool> RegisterStudentToCourseAsync(int courseId, int studentId);


        /// <summary>
        /// Deletes a student who has previously registered for a course from the course he/she is registered for.
        /// </summary>
        /// <param name="courseId">Takes the course Id parameter.</param>
        /// <param name="studentId">Takes the Student Id parameter.</param>
        /// <returns>Returns a value of type true or false</returns>
        Task<bool> DeregisterStudentFromCourseAsync(int courseId, int studentId);

    }
}
