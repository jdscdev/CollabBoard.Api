using System.ComponentModel.DataAnnotations;

namespace CollabBoard.Api.DTOs
{
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}