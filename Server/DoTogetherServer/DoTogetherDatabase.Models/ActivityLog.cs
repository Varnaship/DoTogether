using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class ActivityLog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        [MaxLength(DatabaseConstants.ActivityLogActionMaxLength)]
        public string Action { get; set; } = null!;

        [Required]
        public DateTime Timestamp { get; set; }

        [MaxLength(DatabaseConstants.ActivityLogDetailsMaxLength)]
        public string? Details { get; set; }
    }
}