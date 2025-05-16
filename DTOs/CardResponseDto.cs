using System.ComponentModel.DataAnnotations;

namespace CollabBoard.Api.DTOs
{
    public class CardResponsetDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}