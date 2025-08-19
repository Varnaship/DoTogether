using System.ComponentModel.DataAnnotations;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DatabaseConstants.UserNameMaxLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [MaxLength(DatabaseConstants.EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(DatabaseConstants.PasswordHashMaxLength)]
        public string PasswordHash { get; set; } = null!;

        public ICollection<UserWorkspaceRole> UserWorkspaceRoles { get; set; } = new List<UserWorkspaceRole>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}