using System.ComponentModel.DataAnnotations;

namespace Messages.Data.Models
{
    public class Channel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
