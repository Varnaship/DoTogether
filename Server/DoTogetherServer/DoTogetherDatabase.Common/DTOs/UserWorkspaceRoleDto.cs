namespace DoTogetherDatabase.Common.DTOs
{
    public class UserWorkspaceRoleDto
    {
        public Guid UserId { get; set; }
        public Guid WorkspaceId { get; set; }
        public string Role { get; set; } = null!;
    }
}