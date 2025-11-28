using Microsoft.EntityFrameworkCore;
using Todo.Domain;
using Todo.Repositories.Context;

namespace Todo.Repositories;

public class NoteRepository: INoteRepository
{
    readonly NoteDbContext _context;
    public NoteRepository(NoteDbContext context)
    {
        _context = context;
    }

    public async Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Notes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Notes.ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(Note note, CancellationToken cancellationToken = default)
    {
        
        await _context.Notes.AddAsync(note, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
    {
        
        var existingNote = await _context.Notes.FindAsync(note.Id);
        if (existingNote != null)
        {
            existingNote.Title = note.Title;
            existingNote.UpdatedAt = note.UpdatedAt;
            await _context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            throw new Exception("Note not found");
        }
    }

    public async Task DeleteAsync(Note note, CancellationToken cancellationToken = default)
    {
        _context.Notes.Remove(note);
        await _context.SaveChangesAsync(cancellationToken);
    }


}
