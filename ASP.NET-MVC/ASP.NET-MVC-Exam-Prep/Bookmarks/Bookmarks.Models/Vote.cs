using System.ComponentModel.DataAnnotations;

namespace Bookmarks.Models
{
    public class Vote
    {
        public int Id { get; set; }

        [Required]
        public virtual Bookmark Bookmark { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}