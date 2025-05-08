using CollabBoard.Api.Models;

namespace CollabBoard.Api.Repositories
{
    public interface IBoardRepository
    {
        Task<IEnumerable<Board>> GetAllAsync();
        Task<Board?> GetByIdAsync(int id);
        Task AddAsync(Board board);
        Task UpdateAsync(Board board);
        Task DeleteAsync(Board board);
    }
}