using System.Data.Entity.Migrations;

namespace Ajax.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AjaxContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AjaxContext context)
        {
        }
    }
}