using FK3_skilaverkefni_EF_Core.Models;
using FK3_skilaverkefni_EF_Core.Models.DTO;
using FK3_Skilaverkefni_WebApi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace FK3_Skilaverkefni_WebApi.Controllers
{
    [Route("api/students")]
    [Controller]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository _repository;

        public StudentsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDTO>>> GetAllStudents()
        {
            try
            {
                List<StudentDTO> students = await _repository.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            try
            {
                StudentDTO student = await _repository.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(student);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent([FromBody] Student student)
        {
            try
            {
              if (ModelState.IsValid)
                {
                   await _repository.AddStudentAsync(student);
                    return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, student);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                Student stud = await _repository.UpdateStudentAsync(id, student);
                if (stud == null)
                {

                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetStudentById), new { id = stud.StudentId }, stud);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Student>> DeleteStudentAsync(int id)
        {
            try
            {
                bool success = await _repository.DeleteStudentAsync(id);
                if (success)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework like Serilog, NLog, etc.)
                Console.WriteLine($"Error deleting student with id {id}: {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
