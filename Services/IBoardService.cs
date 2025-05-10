using CollabBoard.Api.Models;

namespace CollabBoard.Api.Services
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> GetBoardsAsync();
        Task<Board?> GetBoardAsync(int id);
        Task<Board> CreateBoardAsync(string name);
        Task DeleteBoardAsync(int id);
    }
}