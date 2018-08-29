namespace Bookmarks.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string Text { get; set; }

        public virtual Bookmark Bookmark { get; set; }
    }
}