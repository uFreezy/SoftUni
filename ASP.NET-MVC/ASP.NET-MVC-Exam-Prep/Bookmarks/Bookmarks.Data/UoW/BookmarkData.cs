using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text.RegularExpressions;
using Bookmarks.Data.Repositories;
using Bookmarks.Models;

namespace Bookmarks.Data.UoW
{
    public class BookmarkData : IBookmarkData
    {
        private readonly DbContext _dbContext;

        private readonly IDictionary<Type, object> _repositories;

        public BookmarkData()
            : this(new BookmarksContext())
        {
        }

        public BookmarkData(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this._repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users => this.GetRepository<ApplicationUser>();

        public IRepository<Bookmark> Bookmarks => this.GetRepository<Bookmark>();

        public IRepository<Category> Categories => this.GetRepository<Category>();

        public IRepository<Comment> Comments => this.GetRepository<Comment>();

        public IRepository<Vote> Votes => this.GetRepository<Vote>();

        public int SaveChanges()
        {
            return this._dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this._repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EntityFrameworkRepository<T>);
                this._repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this._dbContext));
            }

            return (IRepository<T>)this._repositories[typeof(T)];
        }
    }
}