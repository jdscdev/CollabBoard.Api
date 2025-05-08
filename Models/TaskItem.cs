namespace CollabBoard.Api.Models
{
   // TaskItem.cs
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int BoardId { get; set; }
        public Board Board { get; set; } = null!;
        public List<Comment> Comments { get; set; } = [];
    }
}