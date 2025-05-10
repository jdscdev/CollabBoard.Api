using CollabBoard.Api.Models;

namespace CollabBoard.Api.Repositories
{
    public interface IBoardRepository
    {
        Task<IEnumerable<Board>> GetAllAsync();
        Task<Board?> GetByIdAsync(int id);
        Task<Board> CreateAsync(Board board);
        Task DeleteAsync(int id);
    }
}