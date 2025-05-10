using CollabBoard.Api.Data;
using CollabBoard.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollabBoard.Api.Repositories
{
    public class ListRepository(ApplicationDbContext dbContext) : IListRepository
    {
        private readonly ApplicationDbContext _context = dbContext;
        
        public async Task<IEnumerable<List>> GetByBoardIdAsync(int boardId) =>
            await _context.Lists.Where(l => l.BoardId == boardId).Include(l => l.Cards).ToListAsync();

        public async Task<List> CreateAsync(List list)
        {
            _context.Lists.Add(list);
            await _context.SaveChangesAsync();
            return list;
        }

        public async Task DeleteAsync(int id)
        {
            var l = await _context.Lists.FindAsync(id);
            if (l != null) _context.Lists.Remove(l);
            await _context.SaveChangesAsync();
        }
    }
}