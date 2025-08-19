using AutoMapper;
using DoTogetherDatabase.Common.DTOs;
using DoTogetherDatabase.Models;

namespace DoTogetherDatabase.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Workspace, WorkspaceDto>();
            CreateMap<Project, ProjectDto>();
            CreateMap<List, ListDto>();
            CreateMap<Models.Task, TaskDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Attachment, AttachmentDto>();
            CreateMap<Invitation, InvitationDto>();
            CreateMap<UserWorkspaceRole, UserWorkspaceRoleDto>();
            CreateMap<Notification, NotificationDto>();
            CreateMap<ActivityLog, ActivityLogDto>();
            CreateMap<ChatRoom, ChatRoomDto>();
            CreateMap<ChatMessage, ChatMessageDto>();
        }
    }
}