namespace Messages.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using Messages.Data;

    public sealed class MessagesDbMigrationConfiguration : DbMigrationsConfiguration<MessagesDbContext>
    {
        public MessagesDbMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MessagesDbContext context)
        {
        }
    }
}
