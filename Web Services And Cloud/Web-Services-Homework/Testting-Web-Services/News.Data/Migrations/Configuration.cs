using System.Data.Entity.Migrations;

namespace News.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsContext context)
        {
        }
    }
}