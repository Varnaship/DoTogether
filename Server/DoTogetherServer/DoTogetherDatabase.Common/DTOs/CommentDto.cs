namespace DoTogetherDatabase.Common.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
    }
}