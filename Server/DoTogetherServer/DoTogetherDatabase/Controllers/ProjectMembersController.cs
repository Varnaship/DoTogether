using DoTogetherDatabase.Common.DTOs;
using DoTogetherDatabase.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoTogetherDatabase.Helpers;

namespace DoTogetherDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class ProjectMembersController : ControllerBase
    {
        private readonly IProjectMemberService _service;

        public ProjectMembersController(IProjectMemberService service)
        {
            _service = service;
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<IEnumerable<ProjectMemberDto>>> GetMembers(Guid projectId)
        {
            var members = await _service.GetMembersAsync(projectId);
            return Ok(members);
        }

        [HttpPost("invite")]
        public async Task<ActionResult<ProjectMemberDto>> Invite(Guid projectId, Guid userId, string role, string? inviteCode = null)
        {
            var member = await _service.InviteAsync(projectId, userId, role, inviteCode);
            if (member == null) return BadRequest();
            return Ok(member);
        }

        [HttpPost("join")]
        public async Task<IActionResult> Join(Guid projectId, Guid userId, string inviteCode)
        {
            var success = await _service.JoinAsync(projectId, userId, inviteCode);
            if (!success) return BadRequest();
            return NoContent();
        }

        [HttpDelete("kick/{memberId}")]
        public async Task<IActionResult> Kick(Guid memberId)
        {
            var currentUserId = UserHelper.GetUserId(User) ?? Guid.Empty;
            var success = await _service.KickAsync(memberId, currentUserId);
            if (!success) return Forbid();
            return NoContent();
        }

        [HttpDelete("leave/{memberId}")]
        public async Task<IActionResult> Leave(Guid memberId)
        {
            var success = await _service.LeaveAsync(memberId);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}