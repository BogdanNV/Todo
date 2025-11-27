using Todo.NoteProfiles;
using Todo.Repositories;
using Todo.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddNoteRepository();
builder.Services.AddNoteServices();
builder.Services.AddAutoMapper(typeof(NoteProfile));


var app = builder.Build();



app.Run();

