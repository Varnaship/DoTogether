using AutoMapper;
using DoTogetherDatabase.Common.DTOs;
using DoTogetherDatabase.Data;
using DoTogetherDatabase.Models;
using DoTogetherDatabase.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoTogetherDatabase.Services
{
    public class CommentService : ICommentService
    {
        private readonly DoTogetherDbContext _context;
        private readonly IMapper _mapper;

        public CommentService(DoTogetherDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> GetAllByTaskIdAsync(Guid taskId)
        {
            var comments = await _context.Comments
                .Where(c => c.TaskId == taskId)
                .ToListAsync();
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<CommentDto?> GetByIdAsync(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);
            return comment == null ? null : _mapper.Map<CommentDto>(comment);
        }

        public async Task<CommentDto> CreateAsync(CommentDto dto)
        {
            var entity = _mapper.Map<Comment>(dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            _context.Comments.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<CommentDto>(entity);
        }

        public async Task<bool> UpdateAsync(Guid id, CommentDto dto)
        {
            var entity = await _context.Comments.FindAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Comments.FindAsync(id);
            if (entity == null) return false;
            _context.Comments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

