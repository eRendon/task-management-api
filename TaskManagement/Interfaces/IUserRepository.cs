using Microsoft.AspNetCore.Identity;
using TaskManagement.Models;

namespace TaskManagement.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByIdAsync(string userId);        
    }
}
