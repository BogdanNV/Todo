using Todo.NoteProfiles;
using Todo.Repositories;
using Todo.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddNoteRepository();
builder.Services.AddNoteServices();
builder.Services.AddAutoMapper(typeof(NoteProfile));
builder.Services.AddSwaggerGen();


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();

