using DoTogetherDatabase.Common.DTOs;

namespace DoTogetherDatabase.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllAsync();
        Task<ProjectDto?> GetByIdAsync(Guid id);
        Task<ProjectDto> CreateAsync(ProjectDto dto);
        Task<bool> UpdateAsync(Guid id, ProjectDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SetPublicAsync(Guid id, bool isPublic, Guid currentUserId);
    }
}