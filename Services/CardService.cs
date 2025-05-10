using CollabBoard.Api.Models;
using CollabBoard.Api.Repositories;

namespace CollabBoard.Api.Services
{
    public class CardService(ICardRepository repo) : ICardService
    {
        private readonly ICardRepository _repo = repo;

        public Task<IEnumerable<Card>> GetCardsByListAsync(int listId) => _repo.GetByListIdAsync(listId);
        public Task<Card> CreateCardAsync(int listId, string content) => _repo.CreateAsync(new Card { ListId = listId, Content = content });
        public Task DeleteCardAsync(int id) => _repo.DeleteAsync(id);
    }

}