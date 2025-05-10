using CollabBoard.Api.Models;

namespace CollabBoard.Api.Repositories
{
    public interface IListRepository
    {
        Task<IEnumerable<List>> GetByBoardIdAsync(int boardId);
        Task<List> CreateAsync(List list);
        Task DeleteAsync(int id);
    }
}