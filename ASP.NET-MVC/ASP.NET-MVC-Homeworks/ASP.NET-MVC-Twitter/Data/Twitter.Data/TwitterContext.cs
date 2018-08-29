using System.Data.Entity;
using ASP.NET_MVC_Twitter.Data.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Twitter.Models;

namespace ASP.NET_MVC_Twitter.Data
{
    public class TwitterContext : IdentityDbContext<ApplicationUser>
    {
        public TwitterContext()
            : base("TwitterContext", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterContext, Configuration>("TwitterContext"));
        }

        public virtual IDbSet<Notification> Notifications { get; set; }
        public virtual IDbSet<Tweet> Tweets { get; set; }
        public virtual IDbSet<Retweet> Retweets { get; set; }
        public virtual IDbSet<Favourite> Favourites { get; set; }
        public virtual IDbSet<Message> Messages { get; set; }
        public virtual IDbSet<TweetReport> TweetReports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Followers)
                .WithMany()
                .Map(a =>
                {
                    a.MapLeftKey("UserId");
                    a.MapRightKey("FollowerId");
                    a.ToTable("UserFollowers");
                });

            modelBuilder.Entity<Notification>()
                .HasRequired(n => n.Receiver)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Sender)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Tweets)
                .WithRequired(t => t.Author)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }
    }
}