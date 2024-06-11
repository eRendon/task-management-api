using Microsoft.AspNetCore.Identity;
using TaskManagement.Models;

namespace TaskManagement.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> FindByEmailAsync(string email);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<SignInResult> SignInAsync(string email, string password, bool rememberMe);
        Task<string> GenerateTokenAsync(User user);
    }
}
