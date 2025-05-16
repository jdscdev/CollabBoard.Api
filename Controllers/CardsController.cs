using CollabBoard.Api.DTOs;
using CollabBoard.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollabBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CardsController(ICardService service) : ControllerBase
    {
        private readonly ICardService _service = service;

        [HttpGet]
        public async Task<IActionResult> Get(int listId) => Ok(await _service.GetCardsByListAsync(listId));
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CardRequestDto cardRequestDto) => Ok(await _service.CreateCardAsync(cardRequestDto));
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) { await _service.DeleteCardAsync(id); return NoContent(); }
    }
}