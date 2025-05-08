namespace CollabBoard.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public List<Board> Boards { get; set; } = [];
    }
}
