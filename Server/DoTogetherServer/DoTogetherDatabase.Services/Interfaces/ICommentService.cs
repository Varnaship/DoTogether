using DoTogetherDatabase.Common.DTOs;

namespace DoTogetherDatabase.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllByTaskIdAsync(Guid taskId);
        Task<CommentDto?> GetByIdAsync(Guid id);
        Task<CommentDto> CreateAsync(CommentDto dto);
        Task<bool> UpdateAsync(Guid id, CommentDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}