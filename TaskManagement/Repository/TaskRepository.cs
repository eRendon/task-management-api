using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<TaskModel>> GetTasksAsync(string userId)
        {
            return await _context.Tasks.Where(t => t.UserId ==  userId).ToListAsync();
        }

        public async Task<TaskModel> GetTaskByIdAsync(int taskId)
        {
            return await _context.Tasks.FindAsync(taskId);
        }

        public async Task<TaskModel> AddTaskAsync(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> UpdateTaskAsync(TaskModel task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task == null)
            {
                return false;
            }

            _context.Tasks.Remove(task!);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
