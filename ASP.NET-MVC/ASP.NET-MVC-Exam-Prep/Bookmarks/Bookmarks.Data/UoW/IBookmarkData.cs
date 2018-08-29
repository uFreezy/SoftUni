using Bookmarks.Data.Repositories;
using Bookmarks.Models;

namespace Bookmarks.Data.UoW
{
    public interface IBookmarkData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Bookmark> Bookmarks { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}