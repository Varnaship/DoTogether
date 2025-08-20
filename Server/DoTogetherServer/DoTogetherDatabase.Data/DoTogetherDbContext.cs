using DoTogetherDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace DoTogetherDatabase.Data
{
    public class DoTogetherDbContext : DbContext
    {
        public DoTogetherDbContext(DbContextOptions<DoTogetherDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Models.Attachment> Attachments { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<UserWorkspaceRole> UserWorkspaceRoles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite key for UserWorkspaceRole
            modelBuilder.Entity<UserWorkspaceRole>()
                .HasKey(uwr => new { uwr.UserId, uwr.WorkspaceId });
        }
    }
}