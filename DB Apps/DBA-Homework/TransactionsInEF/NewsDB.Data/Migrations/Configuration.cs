using NewsDB.Models;

namespace NewsDB.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsDB.Data.NewsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "NewsDB.Data.NewsDBContext";
        }

        protected override void Seed(NewsDB.Data.NewsDBContext context)
        {
            context.News.AddOrUpdate(
                n => n.Content,
                new News()
                {
                    Content =
                       "Visual Studio 2015 RTM!\r\n" +
                       "Today, we are happy to announce the release of Visual Studio 2015 RTM. " +
                       "This Release to Manufacturing (RTM) of Visual Studio includes many new features and updates, " +
                       "such as tools for Universal Windows app development, cross-platform mobile development for iOS, " +
                       "Android, and Windows, including Xamarin, Apache Cordova, Unity, and more."

                },
                 new News() { Content = "Few days until WIndows 10 to get out of \"the factory\"!" },
                 new News() { Content = "Sofia is the next \"Silicon Valley\"." },
                 new News() { Content = "Microsoft Cortana is going to be multyplatform." });
            context.SaveChanges();
        }
    }
}
