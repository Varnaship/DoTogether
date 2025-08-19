using DoTogetherDatabase.Common.DTOs;

namespace DoTogetherDatabase.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllAsync();
        Task<TaskDto?> GetByIdAsync(Guid id);
        Task<TaskDto> CreateAsync(TaskDto dto);
        Task<bool> UpdateAsync(Guid id, TaskDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}