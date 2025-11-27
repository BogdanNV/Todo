namespace Todo.Services;

public static class ServiceExtensions
{
    public static IServiceCollection AddNoteServices(this IServiceCollection services)
    {
        services.AddScoped<INoteService, NoteService>();
        return services;
    }
}
