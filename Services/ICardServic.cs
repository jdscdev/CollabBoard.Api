using CollabBoard.Api.Models;

namespace CollabBoard.Api.Services
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetCardsByListAsync(int listId);
        Task<Card> CreateCardAsync(int listId, string content);
        Task DeleteCardAsync(int id);
    }
}