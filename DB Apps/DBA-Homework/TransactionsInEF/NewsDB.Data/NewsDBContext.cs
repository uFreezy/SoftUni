using NewsDB.Data.Migrations;

namespace NewsDB.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using NewsDB.Models;

    public class NewsDBContext : DbContext
    {

        public NewsDBContext()
            : base("name=NewsDBContext")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDBContext, Configuration>());
        }

        public virtual DbSet<News> News { get; set; }
    }


}