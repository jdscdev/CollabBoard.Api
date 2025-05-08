using CollabBoard.Api.Models;

namespace CollabBoard.Api.Repositories
{
    public interface IListRepository
    {
        Task<IEnumerable<List>> GetAllAsync();
        Task<List?> GetByIdAsync(int id);
        Task AddAsync(List list);
        Task UpdateAsync(List list);
        Task DeleteAsync(List list);
    }
}