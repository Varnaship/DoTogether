using AutoMapper;
using DoTogetherDatabase.Common.DTOs;
using DoTogetherDatabase.Data;
using DoTogetherDatabase.Models;
using DoTogetherDatabase.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoTogetherDatabase.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DoTogetherDbContext _context;
        private readonly IMapper _mapper;

        public ProjectService(DoTogetherDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _context.Projects.ToListAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<ProjectDto?> GetByIdAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            return project == null ? null : _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> CreateAsync(ProjectDto dto)
        {
            var entity = _mapper.Map<Project>(dto);
            entity.Id = Guid.NewGuid();
            _context.Projects.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(entity);
        }

        public async Task<bool> UpdateAsync(Guid id, ProjectDto dto)
        {
            var entity = await _context.Projects.FindAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Projects.FindAsync(id);
            if (entity == null) return false;
            _context.Projects.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetPublicAsync(Guid projectId, bool isPublic, Guid currentUserId)
        {
            var project = await _context.Projects
                .Include(p => p.Members)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null || project.Members == null)
                return false;

            var owner = project.Members.FirstOrDefault(m => m.Role == "Owner");
            if (owner == null || owner.UserId != currentUserId)
                return false; // Only owner can change

            project.IsPublic = isPublic;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}