namespace CourseManagement.Services.Abstract
{
    public interface IReservationService
    {
        Task<bool> RegisterStudentToCourseAsync(int courseId, int studentId);
        Task<bool> DeregisterStudentFromCourseAsync(int courseId, int studentId);
    }
}
