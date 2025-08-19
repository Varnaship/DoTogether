namespace DoTogetherDatabase.Common.DTOs
{
    public class ListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid ProjectId { get; set; }
    }
}