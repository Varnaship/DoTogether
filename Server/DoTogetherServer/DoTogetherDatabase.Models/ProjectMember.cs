using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoTogetherDatabase.Models
{
    public class ProjectMember
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public string Role { get; set; } = "Member"; // "Owner" or "Member"

        public string? InviteCode { get; set; }
    }
}