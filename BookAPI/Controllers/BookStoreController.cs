using BookAPI.Models;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class BookStoreController : ControllerBase
    {
        private readonly IBookRepository _repo;

        public BookStoreController(IBookRepository bookRepository)
        {
            _repo = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            try
            {
                return Ok(await _repo.GetAllAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _repo.GetAsync(id);
            return model == null ? NotFound() : Ok(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(BookModels model)
        {
            try
            {
                var newModelId = await _repo.AddAsync(model);
                var newmodel = await _repo.GetAsync(newModelId);
                return model == null ? NotFound() : Ok(newmodel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] BookModels model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (await _repo.UpdateAsync(id, model) == -1)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (await _repo.DeleteAsync(id) == -1)
                return NotFound();
            return Ok();
        }
    }
}
