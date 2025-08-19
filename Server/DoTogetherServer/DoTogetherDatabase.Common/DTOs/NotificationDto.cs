namespace DoTogetherDatabase.Common.DTOs
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }
}