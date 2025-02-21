using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Core.Interfaces;
using ProjectManagement.Infrastructure.Data;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects
                .Include(p => p.Customer)
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> CreateAsync(Project entity)
        {
            _context.Projects.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Project entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GenerateProjectNumberAsync()
        {
            var lastProject = await _context.Projects
                .OrderByDescending(p => p.ProjectNumber)
                .FirstOrDefaultAsync();

            if (lastProject == null)
                return "P-101";

            var currentNumber = int.Parse(lastProject.ProjectNumber.Split('-')[1]);
            return $"P-{currentNumber + 1}";
        }

        public async Task<IEnumerable<Project>> GetProjectsWithCustomersAsync()
        {
            return await _context.Projects
                .Include(p => p.Customer)
                .ToListAsync();
        }
    }
}