using System.ComponentModel.DataAnnotations;

namespace CollabBoard.Api.DTOs
{
    public class CardRequestDto
    {
        [Required]
        public string Content { get; set; } = null!;
        [Required]
        public int ListId { get; set; } = 0;
    }
}