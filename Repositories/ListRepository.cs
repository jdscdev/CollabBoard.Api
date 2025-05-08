using CollabBoard.Api.Data;
using CollabBoard.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollabBoard.Api.Repositories
{
    public class ListRepository(ApplicationDbContext dbContext) : IListRepository
    {
        private readonly ApplicationDbContext _context = dbContext;
        
        public async Task<IEnumerable<List>> GetAllAsync()
        {
            return await _context.Lists.ToListAsync();
        }

        public async Task<List?> GetByIdAsync(int id)
        {
            return await _context.Lists.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddAsync(List list)
        {
            _context.Lists.Add(list);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(List list)
        {
            _context.Lists.Update(list);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(List list)
        {
            _context.Lists.Remove(list);
            await _context.SaveChangesAsync();
        }
    }
}