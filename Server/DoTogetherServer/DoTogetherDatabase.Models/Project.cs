using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DatabaseConstants.ProjectNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public Guid WorkspaceId { get; set; }

        [ForeignKey(nameof(WorkspaceId))]
        public Workspace Workspace { get; set; } = null!;

        public ICollection<List> Lists { get; set; } = new List<List>();
    }
}