using System.Data.Entity.Migrations;

namespace ASP.NET_MVC_Twitter.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TwitterContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterContext context)
        {
        }
    }
}