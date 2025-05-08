namespace CollabBoard.Api.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}