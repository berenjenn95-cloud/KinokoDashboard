using KinokoBackend.Application.Repository;
using KinokoBackend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace KinokoBackend.API.Controllers
{
    [ApiController]
    [Route("api/songs")]
    public class SongsController : ControllerBase
    {
        private readonly ISongRepository _repo;

        public SongsController(ISongRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Song song)
        {
            await _repo.AddAsync(song);
            return Ok(song);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Song? resp = await _repo.GetByIdAsync(id);

            if (resp == null)
            {
                return NotFound();
            }

            return Ok(resp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var songs = await _repo.GetAllAsync();
            return Ok(songs);
        }
    }
}
