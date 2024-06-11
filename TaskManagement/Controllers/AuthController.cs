using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TaskManagement.Interfaces;
using TaskManagement.Models;
using TaskManagement.Settings;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _userRepository;
        private readonly AppSettings _appSettings;

        public AuthController(IAuthRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var existingUser = await _userRepository.FindByEmailAsync(registerModel.Email);
            if (existingUser != null)
            {
                return BadRequest("El correo electronico ya esta en uso.");
            }

            var newUser = new User { Email = registerModel.Email, UserName = registerModel.UserName };

            var results = await _userRepository.CreateAsync(newUser, registerModel.Password);
            if (!results.Succeeded)
            {
                return BadRequest(results.Errors);
            }

            return Ok(newUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var results = await _userRepository.SignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe);
            if (results.Succeeded)
            {
                var user = await _userRepository.FindByEmailAsync(loginModel.Email);
                var token = await _userRepository.GenerateTokenAsync(user);
                
                return Ok(new { token });
            }
            else
            {
                return BadRequest("Credenciales no validas");
            }
        }
        
    }
}
