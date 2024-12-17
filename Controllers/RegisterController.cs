using System;
using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AuthDatabaseContext _databaseContext;


        public RegisterController(AuthDatabaseContext context)
        {
            _databaseContext = context ?? throw new ArgumentNullException(nameof(context)); // Verifica se o DbContext foi passado corretamente
        }




        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verificar se o usuário com o mesmo email já existe
            var existingUser = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
                return Conflict("User with this email already exists.");

            // Adicionar o novo usuário
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "User registered successfully",
                user.Id,
                user.Name,
                user.Email,
                user.CreateAt
            });
        }

    }
}
