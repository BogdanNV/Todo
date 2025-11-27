using Todo.Domain;
using Todo.Models.Request;
using Todo.Repositories;

namespace Todo.Services;

public class NoteService: INoteService
{
    readonly INoteRepository _repository;
    public NoteService(INoteRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(Note note, CancellationToken cancellationToken = default)
    {
        note.CreatedAt = DateTime.UtcNow;
        note.UpdatedAt = DateTime.UtcNow;

        await _repository.CreateAsync(note, cancellationToken);
    }

    public async Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    public async Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var note = await _repository.GetByIdAsync(id, cancellationToken);
        if(note is null)
        {
            throw new Exception("Note not found");
        }
        return note;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var note = await _repository.GetByIdAsync(id, cancellationToken);

        if(note is null)
        {
            throw new Exception("Note not found");
        }

        await _repository.DeleteAsync(note, cancellationToken);
    }

    public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
    {
        note.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(note, cancellationToken);
    }
}
