using CollabBoard.Api.DTOs;
using CollabBoard.Api.Models;

namespace CollabBoard.Api.Services
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> GetBoardsAsync();
        Task<Board?> GetBoardAsync(int id);
        Task<Board> CreateBoardAsync(BoardRequestDto boardRequestDto);
        Task DeleteBoardAsync(int id);
    }
}