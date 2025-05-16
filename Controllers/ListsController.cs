using CollabBoard.Api.DTOs;
using CollabBoard.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollabBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ListsController(IListService service) : ControllerBase
    {
        private readonly IListService _service = service;

        [HttpGet]
        public async Task<IActionResult> Get(int boardId) => Ok(await _service.GetListsByBoardAsync(boardId));
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ListRequestDto listRequestDto) => Ok(await _service.CreateListAsync(listRequestDto));
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) { await _service.DeleteListAsync(id); return NoContent(); }
    }
}