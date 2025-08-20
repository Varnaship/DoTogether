using DoTogetherDatabase.Common.DTOs;
using DoTogetherDatabase.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoTogetherDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAll()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetById(Guid id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> Create(TaskDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/like")]
        public async Task<IActionResult> Like(Guid id)
        {
            var success = await _service.IncrementLikesAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/dislike")]
        public async Task<IActionResult> Dislike(Guid id)
        {
            var success = await _service.IncrementDislikesAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}