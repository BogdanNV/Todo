using System.ComponentModel.DataAnnotations;

namespace Todo.Domain
{
    public class Note
    {
        [Key]
        public Guid Id {get; set;}

        [Required]
        [MaxLength(160)]
        [MinLength(3)]
        public string Title {get; set;} = String.Empty;

        [Required]
        public DateTime CreatedAt {get; set;}

        [Required]
        public DateTime UpdatedAt {get; set;}

    }
}