using TaskManagement.Models;

namespace TaskManagement.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskModel>> GetTasksAsync(string userId);
        Task<TaskModel> GetTaskByIdAsync(int taskId);
        Task<TaskModel> AddTaskAsync(TaskModel task);
        Task<TaskModel> UpdateTaskAsync(TaskModel task);
        Task<bool> DeleteTaskAsync(int taskId);
    }
}
