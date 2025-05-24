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

            var passwordHash = HashPassword(dto.Password, out var salt);

            var user = new User { Username = dto.Username, PasswordHash = passwordHash, PasswordSalt = salt };
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
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Token = GenerateToken(user)
            };
        }

        private static string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            return Convert.ToBase64String(pbkdf2.GetBytes(32));
        }

        private static bool VerifyPassword(string password, string storedHash, byte[] storedSalt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, 100000, HashAlgorithmName.SHA256);
            var computedHash = Convert.ToBase64String(pbkdf2.GetBytes(32));
            return storedHash == computedHash;
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
                expires: DateTime.UtcNow.AddHours(1),
                issuer: _config["Jwt:Issuer"],
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
