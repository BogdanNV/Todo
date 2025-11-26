using Microsoft.AspNetCore.Mvc;
using Todo.Services;
using Todo.Models.Request;
using Todo.Models.Response;
using Todo.Domain;

namespace Todo.NoteController
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController: ControllerBase
    {
        readonly INoteService _service;
        public NoteController(INoteService noteService)
        {
            _service = noteService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateNoteRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = "Model is not valid."
                });
            }
            await _service.CreateAsync(request.Title);
            return NoContent();
        }

        [HttpGet("/notes")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<Note>>
            {
                Data = result,
                Message = "Done"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(new ApiResponse<Note>
            {
                Data = result,
                Message = "Done"
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] string newText)
        {
            await _service.UpdateAsync(id, newText);
            return NoContent();
        }
    }
}