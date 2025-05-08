using CollabBoard.Api.DTOs;
using CollabBoard.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollabBoard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var user = await _authService.Register(dto);
            if (user == null)
                return BadRequest("Username already exists.");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var user = await _authService.Login(dto);
            if (user == null)
                return Unauthorized("Invalid credentials.");
            return Ok(user);
        }
    }
}