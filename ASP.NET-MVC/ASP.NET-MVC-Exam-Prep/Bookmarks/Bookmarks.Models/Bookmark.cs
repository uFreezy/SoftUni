using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookmarks.Models
{
    public class Bookmark
    {
        public Bookmark()
        {
            this.Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}