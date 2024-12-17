using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly AuthDatabaseContext _databaseContext;

        public LoginController(AuthDatabaseContext context)
        {
            _databaseContext = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        [HttpGet]
        public async Task<IActionResult> loginUser([FromBody] LoginRequest loginRequest)
        {
            var existingUser = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

            if (existingUser == null)
                return Conflict("User with this email not exist.");
            
            var passwordVerification = BCrypt.Net.BCrypt.EnhancedVerify(loginRequest.Password,existingUser.Password);

            if (!passwordVerification)
                return Conflict("Password is incorret!");

            var user = existingUser;

            return Ok(new
                {
                Message = "User logged successfully",
                user.Name,
                user.Id,
                user.Email
                });
        }
    }
}
