using DoTogetherDatabase.Common.DTOs;

namespace DoTogetherDatabase.Services.Interfaces
{
    public interface IProjectMemberService
    {
        Task<IEnumerable<ProjectMemberDto>> GetMembersAsync(Guid projectId);
        Task<ProjectMemberDto?> InviteAsync(Guid projectId, Guid userId, string role, string? inviteCode = null);
        Task<bool> JoinAsync(Guid projectId, Guid userId, string inviteCode);
        Task<bool> KickAsync(Guid memberId, Guid currentUserId);
        Task<bool> LeaveAsync(Guid memberId);
    }
}