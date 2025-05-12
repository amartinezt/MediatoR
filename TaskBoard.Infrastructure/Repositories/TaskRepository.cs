using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Infrastructure.Db;

namespace TaskBoard.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskBoardDbContext _context;

        public TaskRepository(TaskBoardDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task<TaskItem> AddAsync(TaskItem task)
        {
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateAsync(TaskItem task)
        {
            var existing = await _context.TaskItems.FindAsync(task.Id);
            if (existing == null) return false;

            existing.Title = task.Title;
            existing.Description = task.Description;
            existing.IsCompleted = task.IsCompleted;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return false;

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
