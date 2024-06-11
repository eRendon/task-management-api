using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Controllers;
using TaskManagement.Interfaces;
using TaskManagement.Models;
using Moq;
using Xunit;
namespace TaskManagement.Test.Controllers
{
    public class AuthControllerTests
    {
        [Fact]
        public async Task Register_ReturnsBadRequest_WhenUserExists()
        {
            // Arrange
            var mockRepository = new Mock<IAuthRepository>();
            mockRepository.Setup(repo => repo.FindByEmailAsync(It.IsAny<string>()))
                          .ReturnsAsync(new User());

            var controller = new AuthController(mockRepository.Object, null);
            var registerModel = new RegisterModel { Email = "existing@example.com", UserName = "existing", Password = "password" };

            // Act
            var result = await controller.Register(registerModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Register_ReturnsOkResult_WhenUserIsCreated()
        {
            // Arrange
            var mockRepository = new Mock<IAuthRepository>();
            mockRepository.Setup(repo => repo.FindByEmailAsync(It.IsAny<string>()))
                          .ReturnsAsync((User)null);
            mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                          .ReturnsAsync(IdentityResult.Success);

            var controller = new AuthController(mockRepository.Object, null);
            var registerModel = new RegisterModel { Email = "new@example.com", UserName = "new", Password = "password" };

            // Act
            var result = await controller.Register(registerModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Login_ReturnsOkResult_WithToken_WhenCredentialsAreValid()
        {
            // Arrange
            var mockRepository = new Mock<IAuthRepository>();
            mockRepository.Setup(repo => repo.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(new User());
            mockRepository.Setup(repo => repo.FindByEmailAsync(It.IsAny<string>()))
                          .ReturnsAsync(new User());
            mockRepository.Setup(repo => repo.GenerateTokenAsync(It.IsAny<User>()))
                          .ReturnsAsync("sample_token");

            var controller = new AuthController(mockRepository.Object, null);
            var loginModel = new LoginModel { Email = "existing@example.com", Password = "password", RememberMe = true };

            // Act
            var result = await controller.Login(loginModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("sample_token", okResult.Value.GetType().GetProperty("token").GetValue(okResult.Value, null));
        }
    }
}
