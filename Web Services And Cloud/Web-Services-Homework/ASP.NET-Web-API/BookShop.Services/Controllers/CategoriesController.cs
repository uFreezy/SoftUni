namespace BookShop.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BookShop.Models;
    using Data;
    using Models.BindingModels;
    using Models.ViewModels;

    public class CategoriesController : ApiController
    {
        private readonly BookShopContext _context = new BookShopContext();

        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            var categories = this._context.Categories.Select(c => new CategoriesModelView
            {
                Id = c.Id,
                Name = c.Name
            });

            return this.Ok(categories);
        }

        [HttpGet]
        public IHttpActionResult GetCategoryById(int id)
        {
            var category = this._context.Categories
                .Select(c => new CategoriesModelView
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefault(c => c.Id == id);

            return this.Ok(category);
        }

        [HttpPut]
        public IHttpActionResult EditCategoryName(int id, [FromBody] CategoriesBindingModel categ)
        {
            if (!this._context.Categories.Any(c => c.Name == categ.Name))
            {
                var category = this._context.Categories.FirstOrDefault(c => c.Id == id);

                category.Name = categ.Name;

                this._context.SaveChanges();

                return this.Ok("Name changed!");
            }

            return this.BadRequest("Category with that name already exists!");
        }

        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            if (this._context.Categories.Any(c => c.Id == id))
            {
                this._context.Categories.Remove(this._context.Categories.FirstOrDefault(c => c.Id == id));

                this._context.SaveChanges();

                return this.Ok("Successfully deleted!");
            }

            return this.BadRequest("No such category exists!");
        }

        [HttpPost]
        public IHttpActionResult AddCategory([FromBody] CategoriesBindingModel categ)
        {
            if (this._context.Categories.Any(c => c.Name == categ.Name))
            {
                return this.BadRequest("Category with that name already exists!");
            }

            this._context.Categories.Add(new Category
            {
                Name = categ.Name
            });

            this._context.SaveChanges();

            return this.Ok("Category successfully added!");
        }
    }
}