using FK3_skilaverkefni_EF_Core.Models;
using FK3_Skilaverkefni_WebApi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FK3_Skilaverkefni_WebApi.Controllers
{

    [Route("api/subjects")]
    [Controller]
    public class SubjectsController : ControllerBase
    {
        private readonly IRepository _repository;

        public SubjectsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetAllSubjects()
        {
            try
            {
                List<Subject> subjects = await _repository.GetAllSubjectsAsync();
                return Ok(subjects);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject([FromBody] Subject subject)
        {
            try
            {
                await _repository.AddSubjectAsync(subject);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            try
            {
                Subject subject = await _repository.GetSubjectByIdAsync(id);
                if (subject == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(subject);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> UpdateSubject(int id, [FromBody] Subject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.UpdateSubjectAsync(id, subject);
                    return Ok();
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

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteSubject(int id)
        {
            try
            {
                bool result = await _repository.DeleteSubjectAsync(id);
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
