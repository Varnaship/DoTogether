using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class List
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DatabaseConstants.ListNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public Guid ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}