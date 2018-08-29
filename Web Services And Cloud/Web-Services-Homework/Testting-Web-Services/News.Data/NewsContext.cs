using System.Data.Entity;

namespace News.Data
{
    public class NewsContext : DbContext
    {
        public NewsContext()
            : base("NewsContext")
        {
        }

        public virtual DbSet<Models.News> News { get; set; }
    }
}