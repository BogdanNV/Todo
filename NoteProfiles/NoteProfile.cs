using AutoMapper;
using Todo.Domain;
using Todo.Models.Request;

namespace Todo.NoteProfiles;

public class NoteProfile: Profile
{
    public NoteProfile()
    {
        CreateMap<CreateNoteRequest, Note>();
    }
}