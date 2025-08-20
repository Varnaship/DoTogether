using AutoMapper;
using DoTogetherDatabase.Common.DTOs;
using DoTogetherDatabase.Data;
using DoTogetherDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace DoTogetherDatabase.Services
{
    public class TaskService : ITaskService
    {
        private readonly DoTogetherDbContext _context;
        private readonly IMapper _mapper;

        public TaskService(DoTogetherDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto?> GetByIdAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return task == null ? null : _mapper.Map<TaskDto>(task);
        }

        public async Task<TaskDto> CreateAsync(TaskDto dto)
        {
            var entity = _mapper.Map<Models.Task>(dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            _context.Tasks.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaskDto>(entity);
        }

        public async Task<bool> UpdateAsync(Guid id, TaskDto dto)
        {
            var entity = await _context.Tasks.FindAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Tasks.FindAsync(id);
            if (entity == null) return false;
            _context.Tasks.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IncrementLikesAsync(Guid id)
        {
            var entity = await _context.Tasks.FindAsync(id);
            if (entity == null) return false;
            entity.Likes++;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IncrementDislikesAsync(Guid id)
        {
            var entity = await _context.Tasks.FindAsync(id);
            if (entity == null) return false;
            entity.Dislikes++;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}