using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Managers;
using server.Accessors;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("verify")]
        public bool VerifyLogin(string username, string password)
        {
            UserManager um = new UserManager();
            return um.Authenticate(username, password);
        }

        [HttpPost("login")]
        public LoginResponse Login([FromBody] LoginRequest request)
        {
            UserManager um = new UserManager();
            UserAccessor ua = new UserAccessor();
            
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return new LoginResponse 
                { 
                    Success = false, 
                    Message = "Username and password are required" 
                };
            }

            if (!um.Authenticate(request.Username, request.Password))
            {
                return new LoginResponse 
                { 
                    Success = false, 
                    Message = "Invalid username or password" 
                };
            }

            int userId = ua.GetIdFromUsername(request.Username);
            if (userId == -1)
            {
                return new LoginResponse 
                { 
                    Success = false, 
                    Message = "User not found" 
                };
            }

            string accountType = um.GetAccountType(request.Username, request.Password);
            
            return new LoginResponse
            {
                Success = true,
                Message = "Login successful",
                Username = request.Username,
                Role = accountType,
                UserId = userId
            };
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}