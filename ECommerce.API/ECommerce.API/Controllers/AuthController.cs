//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Models;
using Data;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IRepository repo, ILogger<AuthController> logger)
        {
            this._repo = repo;
            this._logger = logger;
        }

        [HttpPost("Register")]
        public ActionResult<string> Register([FromBody] User newUser) {
            // Check if User model is valid
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState);
            // Ensure that all necessary variables have values, if not return error
            if (String.IsNullOrWhiteSpace(newUser.FirstName) || String.IsNullOrWhiteSpace(newUser.LastName) || String.IsNullOrWhiteSpace(newUser.Email) || String.IsNullOrWhiteSpace(newUser.Password))
                return BadRequest(400);
            // Return 409 error code if user with same Email already exists
            if (_repo.EmailTaken(newUser.Email)) {
                _logger.LogWarning($"Attempt to register with existing email: {newUser.Email}");
                return Conflict(409);
            }
            // Register new User
            else {
                _repo.RegisterNewUser(newUser);
                _logger.LogInformation($"New user registered with email: {newUser.Email}");
                return Created("", 201);
            }
        }

        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] User Credentials) {
            // Check if User model is valid
            // if (!ModelState.IsValid) {
            //     return BadRequest(ModelState);
            // }

            // Ensure that all necessary variables have values, if not return error
            if (String.IsNullOrWhiteSpace(Credentials.Email) || String.IsNullOrWhiteSpace(Credentials.Password))
                return BadRequest(400);
            // Return 404 error code if user with Email doesn't exist
            if (!_repo.EmailTaken(Credentials.Email))
                return NotFound(404);

            // Check if a user with matching credentials exists
            User? user = _repo.VerifyCredentials(Credentials.Email, Credentials.Password);
            if (user != null) {
                _logger.LogInformation($"Login success by email: {Credentials.Email}");
                return Ok(user);
            }
            // Return 401 error code if user's password does not match
            else    return Unauthorized(401);
        }

        // [HttpPost("Logout")]
        // public ActionResult Logout()
        // { 
        //     return Ok();
        // }
    }
}
