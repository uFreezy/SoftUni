using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;
using BookShop.Models;

namespace BookShop.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BookShop.Data.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
            if (!context.Authors.Any())
            {
                AddAuthors(context);
            }
            if (!context.Categories.Any())
            {
                AddCategories(context);
            }
            if (!context.Books.Any())
            {
                AddBooks(context);

            }

        }

        private static void AddBooks(BookShopContext context)
        {
            var random = new Random();
            using (var reader = new StreamReader("books.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 6);
                    var authorIndex = random.Next(0, context.Authors.Count());
                    var author = context.Authors.ToList()[authorIndex];
                    var categoryIndex = random.Next(0, context.Categories.Count());
                    var category = context.Categories.ToList()[categoryIndex];
                    var edition = (EditionType)int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (AgeRestriction)int.Parse(data[4]);
                    var title = data[5];

                    context.Books.Add(new Book()
                    {
                        EditionType = edition,
                        ReleaseDate = releaseDate,
                        Copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title,
                        Author = author,
                        Categories = new[] { category }
                    });

                    line = reader.ReadLine();
                }
            }
        }

        private static void AddCategories(BookShopContext context)
        {
            using (var reader = new StreamReader("categories.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var categories = line.Split(new[] { ' ' }, 6, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var categorie in categories)
                    {
                        Category category = new Category()
                        {
                            Name = categorie
                        };
                        context.Categories.Add(category);
                    }
                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }
        }

        private static void AddAuthors(BookShopContext context)
        {
            using (var reader = new StreamReader("authors.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var fullName = line.Split(new[] { '\r' }, 6);
                    foreach (var s in fullName)
                    {
                        var splitFirstAndLastName = s.Split(' ');
                        var firstName = splitFirstAndLastName[0];
                        var lastName = splitFirstAndLastName[1];
                        Author author = new Author()
                        {
                            FirstName = firstName,
                            LastName = lastName
                        };
                        context.Authors.Add(author);
                    }

                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }
        }
    }
}
