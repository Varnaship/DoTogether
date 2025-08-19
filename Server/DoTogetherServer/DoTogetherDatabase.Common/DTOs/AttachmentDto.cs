namespace DoTogetherDatabase.Common.DTOs
{
    public class AttachmentDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = null!;
        public string FileUrl { get; set; } = null!;
        public Guid TaskId { get; set; }
    }
}