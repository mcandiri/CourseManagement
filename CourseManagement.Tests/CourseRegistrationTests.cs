using Xunit;
using CourseManagement.Data;
using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Repositories.Concrete; // Replace with the actual namespace where the repositories are defined
using CourseManagement.Services.Concrete; // Replace with the actual namespace where the services are defined

namespace CourseManagement.Tests
{
    public class CourseRegistrationTests
    {

        private readonly ReservationService _reservationService;

        private readonly AppDbContext _context;
        public CourseRegistrationTests()
        {
            // Setting up an in-memory database for testing purposes
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new AppDbContext(options);
            var courseRepository = new CourseRepository(_context);
            var studentRepository = new StudentRepository(_context);
            _reservationService = new ReservationService(courseRepository, studentRepository);

            // Adding mock students and courses to the in-memory database
            // NOTE: Do not modify this mock data. It is used to ensure consistency in tests.
            _context.Students.Add(new Student
            {
                Id = 1,
                Name = "John",
                Surname = "Doe",
                Email = "john.doe@example.com",
                EnrollmentDate = DateTime.Now,
                IsPriority = true // Priority student
            });

            _context.Courses.AddRange(
                new Course
                {
                    Id = 1,
                    CourseName = "Mathematics 101",
                    Capacity = 30,
                    AvailableSlots = 30,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(3)
                },
                new Course
                {
                    Id = 2,
                    CourseName = "Physics 101",
                    Capacity = 20,
                    AvailableSlots = 20,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(3)
                },
                new Course
                {
                    Id = 3,
                    CourseName = "Chemistry 101",
                    Capacity = 25,
                    AvailableSlots = 25,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(3)
                },
                new Course
                {
                    Id = 4,
                    CourseName = "Biology 101",
                    Capacity = 15,
                    AvailableSlots = 15,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(3)
                },
                new Course
                {
                    Id = 5,
                    CourseName = "History 101",
                    Capacity = 10,
                    AvailableSlots = 10,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(3)
                }
            );

            _context.SaveChanges();
        }


        [Fact]
        public async Task RegisterStudentToCourse_WhenStudentIsPriority_ShouldAllowUpToFiveCourses()
        {
            // Arrange
            var studentId = 1;

            // Act
            // NOTE: The following loop is designed to test priority student registration.
            // Do not modify the loop structure.
            for (int i = 1; i <= 5; i++)
            {
                await _reservationService.RegisterStudentToCourseAsync(i, studentId);
            }

            // Assert
            // NOTE: Do not modify the assertion. It ensures that the priority student can register for up to five courses.
            var studentCoursesCount = _context.StudentCourses.Count(sc => sc.StudentId == studentId);
            Assert.Equal(5, studentCoursesCount); // Priority student should be able to enroll in up to five courses
        }

        [Fact]
        public async Task RegisterStudentToCourse_WhenStudentIsNotPriority_ShouldAllowUpToThreeCourses()
        {
            // Arrange
            // NOTE: The student creation should not be modified. It sets up a non-priority student for testing.
            var student = new Student
            {
                Id = 2,
                Name = "Jane",
                Surname = "Smith",
                Email = "jane.smith@example.com",
                EnrollmentDate = DateTime.Now,
                IsPriority = false // Non-priority student
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            // Act
            // NOTE: This loop tests non-priority student registration. Do not modify this part.
            for (int i = 1; i <= 3; i++)
            {
                await _reservationService.RegisterStudentToCourseAsync(i, student.Id);
            }

            // Assert
            // NOTE: Do not modify the assertion. It ensures that the non-priority student can register for up to three courses.
            var studentCoursesCount = _context.StudentCourses.Count(sc => sc.StudentId == student.Id);
            Assert.Equal(3, studentCoursesCount); // Non-priority student should be able to enroll in up to three courses
        }
    }
}
