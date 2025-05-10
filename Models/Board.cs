namespace CollabBoard.Api.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<List> Lists { get; set; } = [];
    }
}