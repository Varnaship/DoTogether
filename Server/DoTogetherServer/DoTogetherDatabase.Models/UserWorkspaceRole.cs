using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class UserWorkspaceRole
    {
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public Guid WorkspaceId { get; set; }

        [ForeignKey(nameof(WorkspaceId))]
        public Workspace Workspace { get; set; } = null!;

        [Required]
        [MaxLength(DatabaseConstants.UserWorkspaceRoleMaxLength)]
        public string Role { get; set; } = null!; // e.g., "Owner", "Member"
    }
}