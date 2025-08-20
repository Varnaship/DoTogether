namespace DoTogetherDatabase.Common.DTOs
{
    public class ProjectMemberDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public string Role { get; set; } = null!;
        public string? InviteCode { get; set; }
    }
}