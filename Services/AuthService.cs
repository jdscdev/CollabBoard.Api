using CollabBoard.Api.DTOs;
using CollabBoard.Api.Models;
using CollabBoard.Api.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CollabBoard.Api.Services
{
    public class AuthService(IUserRepository userRepo, IConfiguration config) : IAuthService
    {
        private readonly IUserRepository _userRepo = userRepo;
        private readonly IConfiguration _config = config;

        public async Task<UserDto?> Register(UserRegisterDto dto)
        {
            var existingUser = await _userRepo.GetByUsernameAsync(dto.Username);
            if (existingUser != null)
                return null;

            var passwordHash = HashPassword(dto.Password);

            var user = new User { Username = dto.Username, PasswordHash = passwordHash };
            await _userRepo.CreateUserAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Token = GenerateToken(user)
            };
        }

        public async Task<UserDto?> Login(UserLoginDto dto)
        {
            var user = await _userRepo.GetByUsernameAsync(dto.Username);
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
                return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Token = GenerateToken(user)
            };
        }

        private static string HashPassword(string password)
        {
            using var hmac = new HMACSHA256();
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            var hashed = HashPassword(password);
            return storedHash == hashed;
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
