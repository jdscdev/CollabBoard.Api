using CollabBoard.Api.DTOs;

namespace CollabBoard.Api.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int BoardId { get; set; }
        public Board Board { get; set; } = null!;
        public ICollection<Card> Cards { get; set; } = [];
    }
}