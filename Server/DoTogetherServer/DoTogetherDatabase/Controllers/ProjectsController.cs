using DoTogetherDatabase.Common.DTOs;
using DoTogetherDatabase.Helpers;
using DoTogetherDatabase.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoTogetherDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectsController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAll()
        {
            var projects = await _service.GetAllAsync();
            if (!User.Identity?.IsAuthenticated ?? true)
                projects = projects.Where(p => p.IsPublic).ToList();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProjectDto>> GetById(Guid id)
        {
            var project = await _service.GetByIdAsync(id);
            if (project == null) return NotFound();
            if (!project.IsPublic && !(User.Identity?.IsAuthenticated ?? false))
                return Forbid();
            return Ok(project);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProjectDto>> Create(ProjectDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, ProjectDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}/public")]
        [Authorize]
        public async Task<IActionResult> SetPublic(Guid id, [FromQuery] bool isPublic)
        {
            var currentUserId = UserHelper.GetUserId(User) ?? Guid.Empty;
            var success = await _service.SetPublicAsync(id, isPublic, currentUserId);
            if (!success) return Forbid();
            return NoContent();
        }
    }
}