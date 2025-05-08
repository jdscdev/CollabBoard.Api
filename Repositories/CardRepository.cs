using CollabBoard.Api.Data;
using CollabBoard.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollabBoard.Api.Repositories
{
    public class CardRepository(ApplicationDbContext dbContext) : ICardRepository
    {
        private readonly ApplicationDbContext _context = dbContext;

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card?> GetByIdAsync(int id)
        {
            return await _context.Cards.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Card card)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
    }
}