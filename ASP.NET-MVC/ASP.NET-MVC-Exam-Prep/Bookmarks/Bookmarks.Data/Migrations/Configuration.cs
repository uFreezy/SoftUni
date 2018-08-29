using System.Data.Entity.Migrations;

namespace Bookmarks.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookmarksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookmarksContext context)
        {
        }
    }
}