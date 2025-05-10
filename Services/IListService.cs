using CollabBoard.Api.Models;

namespace CollabBoard.Api.Services
{
    public interface IListService
    {
        Task<IEnumerable<List>> GetListsByBoardAsync(int boardId);
        Task<List> CreateListAsync(int boardId, string title);
        Task DeleteListAsync(int id);
    }
}