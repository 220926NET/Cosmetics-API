using Data;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Tests;
public class AuthTests
{
    private readonly Mock<IRepository> _mockRepo;
    private readonly AuthController _controller;

    public AuthTests() {
        _mockRepo = new Mock<IRepository>();
        _controller = new AuthController(_mockRepo.Object, new Logger<AuthController>(Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance));
    }

    [Fact]
    public void Register_InvalidModelState_ReturnsBadRequest()
    {
        // Arrange
        User newUser = new User {Email = "something@email.com", Password = "123456"};

        // Act
        ActionResult<string> result = _controller.Register(newUser);

        // Assert
        _mockRepo.Verify(repo => repo.EmailTaken(It.IsAny<string>()), Times.Never);
        _mockRepo.Verify(repo => repo.RegisterNewUser(It.IsAny<User>()), Times.Never);
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public void Register_WithEmailInDb_ReturnsConflict()
    {
        // Arrange
        string email = "something@email.com";
        User newUser = new User {FirstName = "Random", LastName = "Person", Email = email, Password = "123456"};
        _mockRepo.Setup(repo => repo.EmailTaken(email)).Returns(true);

        // Act
        ActionResult<string> result = _controller.Register(newUser);

        // Assert
        _mockRepo.Verify(repo => repo.EmailTaken(email), Times.Once);
        _mockRepo.Verify(repo => repo.RegisterNewUser(It.IsAny<User>()), Times.Never);
        Assert.IsType<ConflictObjectResult>(result.Result);
    }

    [Fact]
    public void Register_WithValidParams_ReturnsCreated()
    {
        // Arrange
        string email = "something@email.com";
        User newUser = new User {FirstName = "Random", LastName = "Person", Email = email, Password = "123456"};
        _mockRepo.Setup(repo => repo.EmailTaken(email)).Returns(false);

        // Act
        ActionResult<string> result = _controller.Register(newUser);

        // Assert
        _mockRepo.Verify(repo => repo.EmailTaken(email), Times.Once);
        _mockRepo.Verify(repo => repo.RegisterNewUser(newUser), Times.Once);
        Assert.IsType<CreatedResult>(result.Result);
    }


    [Fact]
    public void Login_InvalidModelState_ReturnsBadRequest()
    {
        // Arrange
        User login = new User {Email = "something@email.com", Password = ""};

        // Act
        ActionResult<User> result = _controller.Login(login);

        // Assert
        _mockRepo.Verify(repo => repo.EmailTaken(It.IsAny<string>()), Times.Never);
        _mockRepo.Verify(repo => repo.VerifyCredentials(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public void Login_WithEmailNotInDb_ReturnsNotFound()
    {
        // Arrange
        string email = "something@email.com";
        User login = new User {Email = email, Password = "123456"};
        _mockRepo.Setup(repo => repo.EmailTaken(email)).Returns(false);

        // Act
        ActionResult<User> result = _controller.Login(login);

        // Assert
        _mockRepo.Verify(repo => repo.EmailTaken(email), Times.Once);
        _mockRepo.Verify(repo => repo.VerifyCredentials(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public void Login_WithWrongPassword_ReturnsUnauthorized()
    {
        // Arrange
        string email = "something@email.com", password = "123456";
        User login = new User {Email = email, Password = password};
        _mockRepo.Setup(repo => repo.EmailTaken(email)).Returns(true);
        _mockRepo.Setup(repo => repo.VerifyCredentials(email, password)).Returns<User?>(null);

        // Act
        ActionResult<User> result = _controller.Login(login);

        // Assert
        _mockRepo.Verify(repo => repo.EmailTaken(email), Times.Once);
        _mockRepo.Verify(repo => repo.VerifyCredentials(email, password), Times.Once);
        Assert.IsType<UnauthorizedObjectResult>(result.Result);
        Assert.Equal(null, result.Value);
    }

    [Fact]
    public void Login_WithValidCredentials_ReturnsUserInfo()
    {
        // Arrange
        string email = "something@email.com", password = "123456";
        User login = new User {Email = email, Password = password};
        User info = new User(1, "Random", "Person", "something@email.com");
        _mockRepo.Setup(repo => repo.EmailTaken(email)).Returns(true);
        _mockRepo.Setup(repo => repo.VerifyCredentials(email, password)).Returns(info);

        // Act
        ActionResult<User> result = _controller.Login(login);

        // Assert
        _mockRepo.Verify(repo => repo.EmailTaken(email), Times.Once);
        _mockRepo.Verify(repo => repo.VerifyCredentials(email, password), Times.Once);
        Assert.IsType<OkObjectResult>(result.Result);
    }
}