using ConsoleApp.Context;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ConsoleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentCourseController(StudentContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostStudentCourse(StudentCourse studentCourse)
        {
            try
            {
                _context.Add(studentCourse);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
