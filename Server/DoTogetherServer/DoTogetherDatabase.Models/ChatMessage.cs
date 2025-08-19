using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoTogetherDatabase.Common.Constants;

namespace DoTogetherDatabase.Models
{
    public class ChatMessage
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DatabaseConstants.ChatMessageContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime SentAt { get; set; }

        [Required]
        public Guid SenderId { get; set; }

        [ForeignKey(nameof(SenderId))]
        public User Sender { get; set; } = null!;

        [Required]
        public Guid ChatRoomId { get; set; }

        [ForeignKey(nameof(ChatRoomId))]
        public ChatRoom ChatRoom { get; set; } = null!;
    }
}