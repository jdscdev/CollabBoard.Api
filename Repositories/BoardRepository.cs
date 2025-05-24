using CollabBoard.Api.Data;
using CollabBoard.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollabBoard.Api.Repositories
{
    public class BoardRepository(ApplicationDbContext dbContext) : IBoardRepository
    {
        private readonly ApplicationDbContext _context = dbContext;
        
        public async Task<IEnumerable<Board>> GetAllAsync() => await _context.Boards.Include(b => b.Lists).ToListAsync();

        public async Task<Board?> GetByIdAsync(int id)
        {
            var board = await _context.Boards.Include(b => b.Lists).FirstOrDefaultAsync(b => b.Id == id) ??
                throw new InvalidOperationException($"Board with ID {id} not found.");
            return board;
        }

        public async Task<Board> CreateAsync(Board board)
        {
            _context.Boards.Add(board);
            await _context.SaveChangesAsync();
            return board;
        }
        
        public async Task DeleteAsync(int id)
        {
            var b = await _context.Boards.FindAsync(id);
            if (b != null) _context.Boards.Remove(b);
            await _context.SaveChangesAsync();
        }
    }
}