using System.ComponentModel.DataAnnotations;

namespace CollabBoard.Api.DTOs
{
    public class BoardResponsetDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}