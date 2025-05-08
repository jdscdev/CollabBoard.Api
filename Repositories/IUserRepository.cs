using CollabBoard.Api.Models;

namespace CollabBoard.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<bool> UsernameExistsAsync(string username);
        Task CreateUserAsync(User user);
    }
}