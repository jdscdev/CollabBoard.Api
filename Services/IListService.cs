using CollabBoard.Api.DTOs;
using CollabBoard.Api.Models;

namespace CollabBoard.Api.Services
{
    public interface IListService
    {
        Task<IEnumerable<List>> GetListsByBoardAsync(int boardId);
        Task<List> CreateListAsync(ListRequestDto listRequestDto);
        Task DeleteListAsync(int id);
    }
}