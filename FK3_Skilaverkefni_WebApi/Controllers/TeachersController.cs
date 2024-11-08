using FK3_skilaverkefni_EF_Core.Data;
using FK3_skilaverkefni_EF_Core.Models;
using FK3_skilaverkefni_EF_Core.Models.DTO;
using FK3_Skilaverkefni_WebApi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FK3_Skilaverkefni_WebApi.Controllers
{

    [Route("api/teachers")]
    [Controller]

    public class TeachersController : ControllerBase
    {
        private readonly IRepository _repository;

        public TeachersController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherDTO>>> GetAllTeachers()
        {
            try
            {
                List<TeacherDTO> teachers = await _repository.GetAllTeachersAsync();
                return Ok(teachers);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacherById(int id)
        {
            try
            {
                TeacherDTO teacher = await _repository.GetTeacherByIdAsync(id);
                if (teacher == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(teacher);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.AddTeacherAsync(teacher);
                    return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.TeacherId }, teacher);
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
        public async Task<ActionResult<Teacher>> UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            try
            {
                Teacher teach = await _repository.UpdateTeacherAsync(id, teacher);

                if (teach == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.TeacherId }, teacher);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacherAsync(int id)
        {
            try
            {
                bool result = await _repository.DeleteTeacherAsync(id);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}