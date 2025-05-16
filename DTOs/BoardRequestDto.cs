using System.ComponentModel.DataAnnotations;

namespace CollabBoard.Api.DTOs
{
    public class BoardRequestDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}