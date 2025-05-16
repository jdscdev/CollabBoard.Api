using CollabBoard.Api.DTOs;
using CollabBoard.Api.Models;
using CollabBoard.Api.Repositories;

namespace CollabBoard.Api.Services
{
    public class Listervice(IListRepository repo) : IListService
    {
        private readonly IListRepository _repo = repo;
        
        public async Task<IEnumerable<List>> GetListsByBoardAsync(int boardId) => await _repo.GetByBoardIdAsync(boardId);
        public async Task<List> CreateListAsync(ListRequestDto dto)
        {
            var list = new List { Title = dto.Title, BoardId = dto.BoardId };
            return await _repo.CreateAsync(list);
        }
        public Task DeleteListAsync(int id) => _repo.DeleteAsync(id);
    }

}