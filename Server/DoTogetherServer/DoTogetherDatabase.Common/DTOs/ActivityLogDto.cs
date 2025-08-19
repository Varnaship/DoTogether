namespace DoTogetherDatabase.Common.DTOs
{
    public class ActivityLogDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Action { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public string? Details { get; set; }
    }
}