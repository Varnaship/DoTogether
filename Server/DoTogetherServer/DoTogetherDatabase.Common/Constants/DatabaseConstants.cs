namespace DoTogetherDatabase.Common.Constants
{
    public static class DatabaseConstants
    {
        // User
        public const int UserNameMaxLength = 50;
        public const int EmailMaxLength = 100;
        public const int PasswordHashMaxLength = 256;

        // Workspace
        public const int WorkspaceNameMaxLength = 100;

        // Project
        public const int ProjectNameMaxLength = 100;

        // List
        public const int ListNameMaxLength = 100;

        // Task
        public const int TaskTitleMaxLength = 100;
        public const int TaskDescriptionMaxLength = 500;

        // Comment
        public const int CommentContentMaxLength = 500;

        // Attachment
        public const int AttachmentFileNameMaxLength = 255;
        public const int AttachmentFileUrlMaxLength = 2048;

        // Invitation
        public const int InvitationEmailMaxLength = 100;

        // UserWorkspaceRole
        public const int UserWorkspaceRoleMaxLength = 30;

        // Notification
        public const int NotificationMessageMaxLength = 500;

        // ActivityLog
        public const int ActivityLogActionMaxLength = 100;
        public const int ActivityLogDetailsMaxLength = 1000;

        // ChatRoom
        public const int ChatRoomNameMaxLength = 100;

        // ChatMessage
        public const int ChatMessageContentMaxLength = 1000;

        // Numeric ranges
        public const int MinTaskTitleLength = 1;
        public const int MinUserNameLength = 3;
        public const int MinCommentContentLength = 1;
    }
}