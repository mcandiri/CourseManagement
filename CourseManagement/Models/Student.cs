namespace CourseManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int MaxCoursesAllowed { get; set; } = 3;  // A student can enroll in maximum 3 courses
        public bool IsPriority { get; set; } = false;
    }

}
