using System.ComponentModel.DataAnnotations;

namespace Todo.Models.Request
{
    public class CreateNoteRequest
    {
        [Required]
        [MaxLength(160)]
        [MinLength(3)]
        public string Title {get; set;} = String.Empty;
    }
}