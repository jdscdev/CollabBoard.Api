using CollabBoard.Api.Models;
using CollabBoard.Api.Repositories;

namespace CollabBoard.Api.Services
{
    public class BoardService(IBoardRepository repo) : IBoardService
    {
        private readonly IBoardRepository _repo = repo;

        public Task<IEnumerable<Board>> GetBoardsAsync() => _repo.GetAllAsync();
        public Task<Board?> GetBoardAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Board> CreateBoardAsync(string name) => _repo.CreateAsync(new Board { Name = name });
        public Task DeleteBoardAsync(int id) => _repo.DeleteAsync(id);
    }

}