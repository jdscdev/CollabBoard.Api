using CollabBoard.Api.DTOs;

namespace CollabBoard.Api.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int ListId { get; set; }
        public List List { get; set; } = null!;
    }
}