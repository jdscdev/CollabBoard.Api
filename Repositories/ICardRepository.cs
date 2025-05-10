using CollabBoard.Api.Models;

namespace CollabBoard.Api.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetByListIdAsync(int listId);
        Task<Card> CreateAsync(Card card);
        Task DeleteAsync(int id);
    }
}