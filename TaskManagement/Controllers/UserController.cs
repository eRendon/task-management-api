using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagement.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("get-profile")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized("Usuario no autenticado.");
            }

            var user = await _userRepository.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            var userProfile = new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.PhoneNumber,
                user.EmailConfirmed,
            };

            return Ok(userProfile);
        }
    }
}
