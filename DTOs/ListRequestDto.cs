using System.ComponentModel.DataAnnotations;

namespace CollabBoard.Api.DTOs
{
    public class ListRequestDto
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public int BoardId { get; set; } = 0;
    }
}