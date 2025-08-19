using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class Invitation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid WorkspaceId { get; set; }

        [ForeignKey(nameof(WorkspaceId))]
        public Workspace Workspace { get; set; } = null!;

        [Required]
        [MaxLength(DatabaseConstants.InvitationEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        public DateTime SentAt { get; set; }

        [Required]
        public bool Accepted { get; set; }
    }
}