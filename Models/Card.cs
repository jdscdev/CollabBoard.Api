namespace CollabBoard.Api.Models
{
   // TaskItem.cs
    public class Card
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int ListId { get; set; }
        public List List { get; set; } = null!;
    }
}