namespace DoTogetherDatabase.Common.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid WorkspaceId { get; set; }
    }
}