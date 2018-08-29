using System.Data.Entity;
using BookShop.Data.Migrations;
using BookShop.Models;

namespace BookShop.Data
{
    public class BookShopContext : DbContext
    {
       
        public BookShopContext()
            : base("BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>("BookShopContext"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("Book_Id");
                    m.MapRightKey("RelatedBook_Id");
                    m.ToTable("BookRelations");
                });
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

    }

}