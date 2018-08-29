namespace BookShop.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BookShop.Models;
    using Data;
    using Models.BindingModels;
    using Models.ViewModels;

    public class AuthorsController : ApiController
    {
        private readonly BookShopContext _context = new BookShopContext();

        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var author = this._context.Authors
                .Select(a => new AuthorViewModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Books = this._context.Books
                        .Where(b => b.AuthorId == id)
                        .Select(b => b.Title)
                })
                .FirstOrDefault(a => a.Id == id);

            return this.Ok(author);
        }

        [HttpPost]
        public IHttpActionResult PostAuthor([FromBody] AuthorBindingModel author)
        {
            if (this.ModelState.IsValid && author != null)
            {
                this._context.Authors.Add(new Author
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName
                });

                this._context.SaveChanges();

                return this.Ok(author);
            }

            return this.BadRequest("Something went wrong");
        }

        [HttpGet]
        [Route("api/authors/{id}/books")]
        public IHttpActionResult GetAuthorBooks(int id)
        {
            var books = this._context.Books
                .Where(b => b.AuthorId == id)
                .Select(b => new AuthorBooksViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    EditionType = b.EditionType,
                    AgeRestriction = b.AgeRestriction,
                    Price = b.Price,
                    Copies = b.Copies,
                    ReleaseDate = b.ReleaseDate,
                    Categories = b.Categories.Select(c => c.Name)
                });

            return this.Ok(books);
        }
    }
}