using System.ComponentModel.DataAnnotations;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class Workspace
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DatabaseConstants.WorkspaceNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<UserWorkspaceRole> UserWorkspaceRoles { get; set; } = new List<UserWorkspaceRole>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}