using CollabBoard.Api.Models;
using CollabBoard.Api.Repositories;

namespace CollabBoard.Api.Services
{
    public class Listervice(IListRepository repo) : IListService
    {
        private readonly IListRepository _repo = repo;
        
        public Task<IEnumerable<List>> GetListsByBoardAsync(int boardId) => _repo.GetByBoardIdAsync(boardId);
        public Task<List> CreateListAsync(int boardId, string title) => _repo.CreateAsync(new List { BoardId = boardId, Title = title });
        public Task DeleteListAsync(int id) => _repo.DeleteAsync(id);
    }

}