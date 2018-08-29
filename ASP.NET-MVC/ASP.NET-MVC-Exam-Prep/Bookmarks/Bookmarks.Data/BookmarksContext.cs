using System.Data.Entity;
using Bookmarks.Data.Migrations;
using Bookmarks.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bookmarks.Data
{
    public class BookmarksContext : IdentityDbContext<ApplicationUser>
    {
        public BookmarksContext()
            : base("BookmarksContext", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookmarksContext, Configuration>("BookmarksContext"));
        }

        public static BookmarksContext Create()
        {
            return new BookmarksContext();
        }

        public virtual IDbSet<Bookmark> Bookmarks { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
        public virtual IDbSet<Vote> Votes { get; set; }
    }
}