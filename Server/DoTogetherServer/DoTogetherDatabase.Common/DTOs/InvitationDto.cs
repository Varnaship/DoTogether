namespace DoTogetherDatabase.Common.DTOs
{
    public class InvitationDto
    {
        public Guid Id { get; set; }
        public Guid WorkspaceId { get; set; }
        public string Email { get; set; } = null!;
        public DateTime SentAt { get; set; }
        public bool Accepted { get; set; }
    }
}