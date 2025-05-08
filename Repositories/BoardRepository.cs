using CollabBoard.Api.Data;
using CollabBoard.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollabBoard.Api.Repositories
{
    public class BoardRepository(ApplicationDbContext dbContext) : IBoardRepository
    {
        private readonly ApplicationDbContext _context = dbContext;
        
        public async Task<IEnumerable<Board>> GetAllAsync()
        {
            return await _context.Boards.ToListAsync();
        }

        public async Task<Board?> GetByIdAsync(int id)
        {
            return await _context.Boards.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Board board)
        {
            _context.Boards.Add(board);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Board board)
        {
            _context.Boards.Update(board);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Board board)
        {
            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();
        }
    }
}