using AutoMapper.Configuration.Annotations;
using CollabBoard.Api.DTOs;
using CollabBoard.Api.Models;
using CollabBoard.Api.Repositories;

namespace CollabBoard.Api.Services
{
    public class BoardService(IBoardRepository repo) : IBoardService
    {
        private readonly IBoardRepository _repo = repo;

        public async Task<IEnumerable<Board>> GetBoardsAsync() => await _repo.GetAllAsync();
        public async Task<Board?> GetBoardAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task<Board> CreateBoardAsync(BoardRequestDto dto)
        {
            var board = new Board { Name = dto.Name };
            return await _repo.CreateAsync(board); 
        }
        public Task DeleteBoardAsync(int id) => _repo.DeleteAsync(id);
    }

}