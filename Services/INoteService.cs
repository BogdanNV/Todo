using Todo.Domain;

namespace Todo.Services;

public interface INoteService
{
    Task CreateAsync(string title, CancellationToken cancellationToken = default);

    Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid id, string newText, CancellationToken cancellationToken = default);

}
