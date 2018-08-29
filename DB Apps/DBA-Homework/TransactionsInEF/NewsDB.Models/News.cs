using System.ComponentModel.DataAnnotations;

namespace NewsDB.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string Content { get; set; }

    }
}