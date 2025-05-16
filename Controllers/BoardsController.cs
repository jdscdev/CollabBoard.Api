using CollabBoard.Api.DTOs;
using CollabBoard.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollabBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BoardsController(IBoardService service) : ControllerBase
    {
        private readonly IBoardService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetBoardsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetBoardAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BoardRequestDto boardRequestDto) => Ok(await _service.CreateBoardAsync(boardRequestDto));
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) { await _service.DeleteBoardAsync(id); return NoContent(); }
    }
}