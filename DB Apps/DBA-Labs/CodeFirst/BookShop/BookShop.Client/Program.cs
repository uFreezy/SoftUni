using System;
using System.Linq;
using BookShop.Data;

namespace BookShop.Client
{
    internal class Program
    {
        private static void Main()
        {
            var context = new BookShopContext();

            var BooksCount = context.Books.Count();

            //Problem 6.1

            var Books = context.Books
                .Where(b => b.ReleaseDate > new DateTime(2000, 1, 1))
                .Select(b => new
                {
                    b.Title
                });

            foreach (var book in Books)
            {
                Console.WriteLine("{0}", book.Title);
            }

            //Problem 6.2

            var Authors = context.Authors
                .Where(a => (context.Books.Where(b => b.AuthorId == a.Id && b.ReleaseDate < new DateTime(1990, 1, 1)))
                    .Any())
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                });

            foreach (var author in Authors)
            {
                Console.WriteLine("{0} {1}",
                    author.FirstName,
                    author.LastName);
            }

            //Problem 6.3

            var AuthorsByNum = context.Authors.Select(a => new
            {
                a.FirstName,
                a.LastName,
                BookCount = context.Books.Count(b => b.AuthorId == a.Id)
            }).OrderByDescending(a => a.BookCount);

            foreach (var author in AuthorsByNum)
            {
                Console.WriteLine("{0} {1} {2}",
                    author.FirstName,
                    author.LastName,
                    author.BookCount);
            }

            //Problem 6.4

            var BooksByGeorge = context.Books
                .Where(b => b.Author.FirstName == "George" && b.Author.LastName == "Powell")
                .OrderByDescending(b => b.ReleaseDate)
                .ThenBy(b => b.Title)
                .Select(b => new
                {
                    b.Title,
                    b.ReleaseDate,
                    b.Copies
                });

            foreach (var Book in BooksByGeorge)
            {
                Console.WriteLine("{0} {1} {2}",
                    Book.Title,
                    Book.ReleaseDate,
                    Book.Copies);
            }

            //Problem 6.5

            var TopBooks = context.Categories
                .OrderByDescending(c => c.Books.Count)
                .Select(c => new
                {
                    c.Name,
                    TotalBooks = c.Books.Count,
                    Books = context.Books
                        .Where(b => b.Categories.Any(a => a.Name == c.Name))
                        .OrderByDescending(b => b.ReleaseDate)
                        .ThenBy(b => b.Title)
                        .Take(3)
                        .Select(b => new
                        {
                            b.Title,
                            b.ReleaseDate
                        })
                });

            foreach (var topBook in TopBooks)
            {
                Console.WriteLine("--{0}:  {1} books",
                    topBook.Name,
                    topBook.TotalBooks);
                foreach (var book in topBook.Books)
                {
                    Console.WriteLine("{0} ({1})",
                        book.Title,
                        book.ReleaseDate.Value.Year
                        );   
                }
            }

            //Problem 7

            var books = context.Books
                .Take(3)
                .ToList();

            books[0].RelatedBooks.Add(books[1]);

            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);

            context.SaveChanges();

            foreach (var book in books)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }
        }
    }
}