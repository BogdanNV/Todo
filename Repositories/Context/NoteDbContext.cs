using Microsoft.EntityFrameworkCore;
using Todo.Domain;

namespace Todo.Repositories.Context
{
    public class NoteDbContext: DbContext
    {
        public DbSet<Note> Notes {get; set;}
        public NoteDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}