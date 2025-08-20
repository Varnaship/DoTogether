using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DatabaseConstants.ProjectNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public Guid WorkspaceId { get; set; }
        [ForeignKey(nameof(WorkspaceId))]
        public Workspace Workspace { get; set; } = null!;

        public bool IsPublic { get; set; } = false;

        public ICollection<ProjectMember> Members { get; set; } = new List<ProjectMember>();

        public ICollection<List> Lists { get; set; } = new List<List>();

        public bool CanModify(Guid currentUserId)
        {
            var owner = Members.FirstOrDefault(m => m.Role == "Owner");
            if (owner == null || owner.UserId != currentUserId) return false; // Only owner can change
            return true;
        }
    }
}