namespace DoTogetherDatabase.Common.DTOs
{
    public class ChatRoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? WorkspaceId { get; set; }
        public Guid? ProjectId { get; set; }
    }
}