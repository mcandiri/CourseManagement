namespace CourseManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public int Capacity { get; set; } // course capacity
        public int AvailableSlots { get; set; } // available vacant places
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
