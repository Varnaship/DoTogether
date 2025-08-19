using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DatabaseConstants.CommentContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public Guid TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public Task Task { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}