using ConsoleApp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ConsoleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentId(int id)
        {
            try
            {
                var address = await _context.StudentAddresses.FindAsync(id);
                if (address == null)
                {
                    return NotFound();
                }

                return Ok(address);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            try
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> PutStudent(Student student)
        {
            try
            {
                var studentEncontrado = await _context.Students.FindAsync(student.StudentId);
                if (studentEncontrado == null)
                {
                    return NotFound();
                }
                studentEncontrado.Name = student.Name;
                studentEncontrado.LastName = student.LastName;
                studentEncontrado.StudentAddress.StudentID = student.StudentAddress.StudentID;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);

                if (student == null)
                {
                    return NotFound();
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
