using FK3_skilaverkefni_EF_Core.Models;
using FK3_Skilaverkefni_WebApi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FK3_Skilaverkefni_WebApi.Controllers
{

    [Route("api/marks")]
    [Controller]
    public class MarksController : ControllerBase
    {
        private readonly IRepository _repository;

        public MarksController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mark>>> GetAllMarks()
        {
            try
            {
                List<Mark> marks = await _repository.GetAllMarksAsync();
                return Ok(marks);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Mark>> GetMarkById(int id)
        {
            try
            {
                Mark mark = await _repository.GetMarkByIdAsync(id);
                if (mark == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mark);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Mark>> AddMark([FromBody] Mark mark)
        {
            try
            {
                Mark newMark = await _repository.AddMarkAsync(mark);
                return Created($"/api/marks/{newMark.MarkId}", newMark);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Mark>> UpdateMark(int id, [FromBody] Mark mark)
        {
            try
            {
                Mark updatedMark = await _repository.UpdateMarkAsync(id, mark);
                if (updatedMark == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(updatedMark);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteMark(int id)
        {
            try
            {
                bool result = await _repository.DeleteMarkAsync(id);
                if (result)
                {
                    return NoContent();
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
