using System.Diagnostics;
using CollabBoard.Api.DTOs;
using CollabBoard.Api.Models;
using CollabBoard.Api.Repositories;

namespace CollabBoard.Api.Services
{
    public class CardService(ICardRepository repo) : ICardService
    {
        private readonly ICardRepository _repo = repo;

        public async Task<IEnumerable<Card>> GetCardsByListAsync(int listId) => await _repo.GetByListIdAsync(listId);
        public async Task<Card> CreateCardAsync(CardRequestDto dto)
        {
            var card = new Card { Content = dto.Content, ListId = dto.ListId };
            return await _repo.CreateAsync(card);
        }
        public Task DeleteCardAsync(int id) => _repo.DeleteAsync(id);
    }

}