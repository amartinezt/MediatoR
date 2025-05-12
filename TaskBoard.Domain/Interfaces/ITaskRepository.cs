using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem> AddAsync(TaskItem task);
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(TaskItem task);
        Task<bool> DeleteAsync(Guid id);
    }
}
