using Microsoft.AspNetCore.Mvc;
using CourseManagement.Services.Abstract;

namespace CourseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController(IReservationService reservationService) : ControllerBase
    {
        private readonly IReservationService _reservationService = reservationService;

        [HttpPost("{courseId}/register/{studentId}")]
        public async Task<IActionResult> RegisterStudent(int courseId, int studentId)
        {
            var result = await _reservationService.RegisterStudentToCourseAsync(courseId, studentId);
            if (!result)
                return BadRequest("Failed to register the student. Course is full or student is already registered.");

            return Ok("Student successfully registered to the course.");
        }

        [HttpDelete("{courseId}/deregister/{studentId}")]
        public async Task<IActionResult> DeregisterStudent(int courseId, int studentId)
        {
            var result = await _reservationService.DeregisterStudentFromCourseAsync(courseId, studentId);
            if (!result)
                return BadRequest("Failed to deregister the student.");

            return Ok("Student successfully deregistered from the course.");
        }
    }
}
