using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class ChatRoom
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DatabaseConstants.ChatRoomNameMaxLength)]
        public string Name { get; set; } = null!;

        public Guid? WorkspaceId { get; set; }

        [ForeignKey(nameof(WorkspaceId))]
        public Workspace? Workspace { get; set; }

        public Guid? ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project? Project { get; set; }

        public ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    }
}