using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DatabaseConstants.TaskTitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(DatabaseConstants.TaskDescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public Guid ListId { get; set; }

        [ForeignKey(nameof(ListId))]
        public List List { get; set; } = null!;

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? DueDate { get; set; }

        public Guid? AssignedUserId { get; set; }

        [ForeignKey(nameof(AssignedUserId))]
        public User? AssignedUser { get; set; }
    }
}