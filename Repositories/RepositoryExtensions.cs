using Microsoft.EntityFrameworkCore;
using Todo.Repositories.Context;

namespace Todo.Repositories;

public static class RepositoryExtensions
{
    public static IServiceCollection AddNoteRepository(this IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddDbContext<NoteDbContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Username=postgres;Password=postgres;Database=notesdb;Port=5432");
        });
        return services;
    }
}