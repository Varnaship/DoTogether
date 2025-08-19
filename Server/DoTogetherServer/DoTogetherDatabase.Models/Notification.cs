using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class Notification
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        [MaxLength(DatabaseConstants.NotificationMessageMaxLength)]
        public string Message { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool IsRead { get; set; }
    }
}