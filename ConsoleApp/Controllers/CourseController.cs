using ConsoleApp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ConsoleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly StudentContext _context;

        public CourseController(StudentContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            try
            {
                List<Student> list = await _context.Students.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentId(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostCourse(Course course)
        {
            try
            {
                _context.Add(course);
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
