namespace BookShop.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using BookShop.Models;
    using Data;
    using Models.BindingModels;
    using Models.ViewModels;

    [Authorize]
    public class BooksController : ApiController
    {
        private readonly BookShopContext _context = new BookShopContext();

        [HttpGet]
        public IHttpActionResult GetBookById(int id)
        {
            var book = this._context.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    EditionType = b.EditionType,
                    AgeRestriction = b.AgeRestriction,
                    Price = b.Price,
                    Copies = b.Copies,
                    ReleaseDate = b.ReleaseDate,
                    AuthorId = b.AuthorId,
                    Author = b.Author,
                    Categories = b.Categories.Select(c => c.Name)
                });

            return this.Ok(book);
        }

        [HttpGet]
        [Route("api/books")]
        public IHttpActionResult GetBooksByKeyWord(string search)
        {
            var books = this._context.Books
                .Where(b => b.Title.Contains(search) || b.Description.Contains(search))
                .Take(10)
                .Select(b => new BooksByKeywordViewModel
                {
                    Id = b.Id,
                    Title = b.Title
                });

            return this.Ok(books);
        }

        [HttpPut]
        [Route("api/books/{id}")]
        public IHttpActionResult EditBook(int id, [FromBody] BookBindingModel bookModel)
        {
            var book = this._context.Books.FirstOrDefault(b => b.Id == id);

            book.Title = bookModel.Title;
            book.Description = bookModel.Description;
            book.EditionType = bookModel.EditionType;
            book.AgeRestriction = bookModel.AgeRestriction;
            book.Price = bookModel.Price;
            book.Copies = bookModel.Copies;
            book.ReleaseDate = bookModel.ReleaseDate;
            book.AuthorId = bookModel.AuthorId;
            book.Author = this._context.Authors.FirstOrDefault(a => a.Id == bookModel.AuthorId);

            this._context.SaveChanges();

            return this.Ok("Book edited successfully!");
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            this._context.Books.Remove(this._context.Books.FirstOrDefault(b => b.Id == id));

            this._context.SaveChanges();

            return this.Ok("Book deleted successfully!");
        }

        [HttpPost]
        [Route("api/books")]
        public IHttpActionResult PostBook(BookBindingModel bookModel)
        {
            var catNames = bookModel.Categories.Split(' ');

            ICollection<Category> categories = catNames
                .Select(name => this._context.Categories.FirstOrDefault(c => c.Name == name))
                .ToList();

            this._context.Books.Add(new Book
            {
                Title = bookModel.Title,
                Description = bookModel.Description,
                EditionType = bookModel.EditionType,
                AgeRestriction = bookModel.AgeRestriction,
                Price = bookModel.Price,
                Copies = bookModel.Copies,
                ReleaseDate = bookModel.ReleaseDate,
                AuthorId = bookModel.AuthorId,
                Author = this._context.Authors.FirstOrDefault(a => a.Id == bookModel.AuthorId),
                Categories = categories
            });

            this._context.SaveChanges();

            return this.Ok("Book added successfully!");
        }

        [HttpPut]
        [Route("api/books/buy/{id}")]
        public IHttpActionResult BuyBook(int id, [FromBody] BookPurchaseBindingModel purchase)
        {
            if (this.User.Identity == null)
                return this.Unauthorized();

            if (!this._context.Books.Any(b => b.Id == id))
                return this.BadRequest("Book with this ID doesnt exist!");

            if (this._context.Books.FirstOrDefault(b => b.Id == id).Copies == 0)
                return this.BadRequest("Book is out of stock.");

            this._context.Purchases.Add(new Purchase
            {
                Book = this._context.Books.FirstOrDefault(b => b.Id == id),
                DateOfPurchase = purchase.DateOfPurchase,
                IsRecalled = purchase.IsRecalled,
                Price = purchase.Price,
                User = this._context.Users.FirstOrDefault(u => u.UserName == purchase.User)
            });

            this._context.Configuration.ValidateOnSaveEnabled = false;

            this._context.Books.FirstOrDefault(b => b.Id == id).Copies--;

            this._context.SaveChanges();

            return this.Ok("You successfully purchased: " + this._context.Books.FirstOrDefault(b => b.Id == id).Title);
        }

        [HttpPut]
        [Route("api/books/recall/{id}")]
        public IHttpActionResult RecallBook(int id)
        {
            if (this.User.Identity == null)
                return this.Unauthorized();

            if (!this._context.Books.Any(b => b.Id == id))
                return this.BadRequest("Book with this ID doesnt exist!");

            if (!this._context.Users.Any(u => u.Purchases.Count(p => p.Book.Id == id) > 0))
                return this.BadRequest("You dont have that book.");

            var dateNow = DateTime.Now.AddDays(-30);

            var purchase = this._context.Purchases
                .Where(p => dateNow <= p.DateOfPurchase)
                .OrderBy(p => p.DateOfPurchase).First();

            this._context.Purchases.Remove(purchase);

            this._context.Configuration.ValidateOnSaveEnabled = false;

            this._context.Books.FirstOrDefault(b => b.Id == id).Copies++;

            this._context.SaveChanges();

            return this.Ok("You successfully recalled the book: " +
                           this._context.Books.FirstOrDefault(b => b.Id == id).Title);
        }
    }
}