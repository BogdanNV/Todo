using Microsoft.AspNetCore.Mvc;
using Todo.Services;
using Todo.Models.Request;
using Todo.Models.Response;
using Todo.Domain;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Todo.NoteController
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController: ControllerBase
    {
        readonly INoteService _service;
        readonly IMapper _mapper;
        public NoteController(INoteService noteService, IMapper mapper)
        {
            _service = noteService;
            _mapper = mapper;
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
            var note = _mapper.Map<Note>(request);
            await _service.CreateAsync(note);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<Note>>
            {
                Data = result,
                Message = "Done"
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute, Required] Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(new ApiResponse<Note>
                {
                    Data = result,
                    Message = "Done"
                });
            }
            catch (Exception e)
            {
                
                return BadRequest(new ErrorResponse
                {
                    Message = e.Message
                });
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute, Required] Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent(); 
            }
            catch (Exception e)
            {
                
                return BadRequest(new ErrorResponse
                {
                    Message = e.Message
                });
            }
            
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute, Required] Guid id, 
            [FromBody, Required] CreateNoteRequest request)
        {
            try
            {
                var note = _mapper.Map<Note>(request);
                note.Id = id;
                await _service.UpdateAsync(note);
                return NoContent(); 
            }
            catch (Exception e)
            {
                
                return BadRequest(new ErrorResponse
                {
                    Message = e.Message
                });
            }
        }
    }
}