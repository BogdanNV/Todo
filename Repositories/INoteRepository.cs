using Todo.Domain;

namespace Todo.Repositories;

public interface INoteRepository
{
    Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(Note note, CancellationToken cancellationToken = default);
    Task UpdateAsync(Note note, CancellationToken cancellationToken = default);
    Task DeleteAsync(Note note, CancellationToken cancellationToken = default);
}
