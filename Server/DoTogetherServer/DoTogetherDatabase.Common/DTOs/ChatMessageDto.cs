namespace DoTogetherDatabase.Common.DTOs
{
    public class ChatMessageDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime SentAt { get; set; }
        public Guid SenderId { get; set; }
        public Guid ChatRoomId { get; set; }
    }
}