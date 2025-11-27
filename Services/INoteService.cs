using Todo.Domain;
using Todo.Models.Request;

namespace Todo.Services;

public interface INoteService
{
    Task CreateAsync(Note note, CancellationToken cancellationToken = default);

    Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task UpdateAsync(Note note, CancellationToken cancellationToken = default);

}
