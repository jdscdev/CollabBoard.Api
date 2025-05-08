namespace CollabBoard.Api.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        public List<TaskItem> Tasks { get; set; } = [];
    }
}