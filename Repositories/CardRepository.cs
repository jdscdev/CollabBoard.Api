using CollabBoard.Api.Data;
using CollabBoard.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollabBoard.Api.Repositories
{
    public class CardRepository(ApplicationDbContext dbContext) : ICardRepository
    {
        private readonly ApplicationDbContext _context = dbContext;

        public async Task<IEnumerable<Card>> GetByListIdAsync(int listId) =>
        await _context.Cards.Where(c => c.ListId == listId).ToListAsync();

        public async Task<Card> CreateAsync(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task DeleteAsync(int id)
        {
            var c = await _context.Cards.FindAsync(id);
            if (c != null) _context.Cards.Remove(c);
            await _context.SaveChangesAsync();
        }
    }
}