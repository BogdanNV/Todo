using Todo.Domain;
using Todo.Repositories;

namespace Todo.Services;

public class NoteService: INoteService
{
    readonly INoteRepository _repository;
    public NoteService(INoteRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(string title, CancellationToken cancellationToken = default)
    {
        var note = new Note
        {
            Id = Guid.NewGuid(),
            Title = title,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.CreateAsync(note, cancellationToken);
    }

    public async Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    public async Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var note = await _repository.GetByIdAsync(id, cancellationToken);
        await _repository.DeleteAsync(note, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, string newText, CancellationToken cancellationToken = default)
    {
        var note = await _repository.GetByIdAsync(id, cancellationToken);
        note.Title = newText;
        note.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(note, cancellationToken);
    }
}
