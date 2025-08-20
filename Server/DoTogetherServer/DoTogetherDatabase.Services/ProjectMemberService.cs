using DoTogetherDatabase.Common.DTOs;
using DoTogetherDatabase.Data;
using DoTogetherDatabase.Models;
using DoTogetherDatabase.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoTogetherDatabase.Services
{
    public class ProjectMemberService : IProjectMemberService
    {
        private readonly DoTogetherDbContext _context;

        public ProjectMemberService(DoTogetherDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectMemberDto>> GetMembersAsync(Guid projectId)
        {
            var members = await _context.ProjectMembers
                .Where(pm => pm.ProjectId == projectId)
                .ToListAsync();
            return members.Select(pm => new ProjectMemberDto
            {
                Id = pm.Id,
                ProjectId = pm.ProjectId,
                UserId = pm.UserId,
                Role = pm.Role,
                InviteCode = pm.InviteCode
            });
        }

        public async Task<ProjectMemberDto?> InviteAsync(Guid projectId, Guid userId, string role, string? inviteCode = null)
        {
            var member = new ProjectMember
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                UserId = userId,
                Role = role,
                InviteCode = inviteCode
            };
            _context.ProjectMembers.Add(member);
            await _context.SaveChangesAsync();
            return new ProjectMemberDto
            {
                Id = member.Id,
                ProjectId = member.ProjectId,
                UserId = member.UserId,
                Role = member.Role,
                InviteCode = member.InviteCode
            };
        }

        public async Task<bool> JoinAsync(Guid projectId, Guid userId, string inviteCode)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project == null) return false;

            if (project.IsPublic || await _context.ProjectMembers.AnyAsync(pm => pm.ProjectId == projectId && pm.InviteCode == inviteCode))
            {
                var alreadyMember = await _context.ProjectMembers.AnyAsync(pm => pm.ProjectId == projectId && pm.UserId == userId);
                if (alreadyMember) return false;

                var member = new ProjectMember
                {
                    Id = Guid.NewGuid(),
                    ProjectId = projectId,
                    UserId = userId,
                    Role = "Member"
                };
                _context.ProjectMembers.Add(member);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> KickAsync(Guid memberId, Guid currentUserId)
        {
            var member = await _context.ProjectMembers.FindAsync(memberId);
            if (member == null) return false;

            var project = await _context.Projects
                .Include(p => p.Members)
                .FirstOrDefaultAsync(p => p.Id == member.ProjectId);

            var owner = project?.Members.FirstOrDefault(m => m.Role == "Owner");
            if (owner == null || owner.UserId != currentUserId) return false; // Only owner can kick

            _context.ProjectMembers.Remove(member);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LeaveAsync(Guid memberId)
        {
            var member = await _context.ProjectMembers.FindAsync(memberId);
            if (member == null) return false;
            _context.ProjectMembers.Remove(member);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}