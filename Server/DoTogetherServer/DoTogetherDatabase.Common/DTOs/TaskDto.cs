namespace DoTogetherDatabase.Common.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public Guid ListId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? AssignedUserId { get; set; }
    }
}