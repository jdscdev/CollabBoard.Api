using CollabBoard.Api.DTOs;
using CollabBoard.Api.Models;

namespace CollabBoard.Api.Services
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetCardsByListAsync(int listId);
        Task<Card> CreateCardAsync(CardRequestDto cardRequestDto);
        Task DeleteCardAsync(int id);
    }
}