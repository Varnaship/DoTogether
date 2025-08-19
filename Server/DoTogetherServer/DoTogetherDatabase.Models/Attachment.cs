using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class Attachment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DatabaseConstants.AttachmentFileNameMaxLength)]
        public string FileName { get; set; } = null!;

        [Required]
        [MaxLength(DatabaseConstants.AttachmentFileUrlMaxLength)]
        public string FileUrl { get; set; } = null!;

        [Required]
        public Guid TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public Task Task { get; set; } = null!;
    }
}