using FK3_skilaverkefni_EF_Core.Models;
using FK3_Skilaverkefni_WebApi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FK3_Skilaverkefni_WebApi.Controllers
{

    [Route("api/groups")]
    [Controller]
    public class GroupsController : ControllerBase
    {
        private readonly IRepository _repository;

        public GroupsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Group>>> GetAllGroups()
        {
            try
            {
                List<Group> groups = await _repository.GetAllGroupsAsync();
                return Ok(groups);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup([FromBody] Group group)
        {
            try
            {
                await _repository.AddGroupAsync(group);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Group>> GetGroupById(int id)
        {
            try
            {
                Group group = await _repository.GetGroupByIdAsync(id);
                if (group == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(group);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> UpdateGroup(int id, [FromBody] Group group)
        {
            try
            {
                Group updatedGroup = await _repository.UpdateGroupAsync(id, group);
                if (updatedGroup == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(updatedGroup);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            try
            {
                bool success = await _repository.DeleteGroupAsync(id);
                if (success)
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
