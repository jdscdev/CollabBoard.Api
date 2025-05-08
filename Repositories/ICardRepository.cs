using CollabBoard.Api.Models;

namespace CollabBoard.Api.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetAllAsync();
        Task<Card?> GetByIdAsync(int id);
        Task AddAsync(Card card);
        Task UpdateAsync(Card card);
        Task DeleteAsync(Card card);
    }
}