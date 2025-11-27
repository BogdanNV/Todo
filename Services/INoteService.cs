using Todo.Domain;
using Todo.Models.Request;

namespace Todo.Services;

public interface INoteService
{
    Task CreateAsync(string title, CancellationToken cancellationToken = default);

    Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid id, CreateNoteRequest request, CancellationToken cancellationToken = default);

}
