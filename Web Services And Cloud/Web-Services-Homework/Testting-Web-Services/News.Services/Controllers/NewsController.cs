using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using News.Data;
using News.Services.Models.BindingModels;
using News.Services.Models.ViewModels;

namespace News.Services.Controllers
{
    public class NewsController : BaseApiController
    {
        public NewsController()
        {
            
        }

        public NewsController(INewsData data)
            : base(data)
        {
        }

        //GET /api/news
        [HttpGet]
        [Route("api/news")]
        public IHttpActionResult GetAllNews()
        {
            if (!Data.News.All().Any())
                return BadRequest("No news.");

            var news = Data.News.All()
                .OrderByDescending(n => n.PublishDate)
                .Select(n => new NewsViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    PostedOn = n.PublishDate
                });

            return Ok(news);
        }

        //POST /api/news
        [HttpPost]
        [Route("api/news")]
        public IHttpActionResult PostNews([FromBody] NewsBindingModel m)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (m.Title == null || m.Content == null)
                return BadRequest();

            var news = new News.Models.News
            {
                Title = m.Title,
                Content = m.Content,
                PublishDate = m.PublishedOn
            };

            Data.News.Add(news);

            Data.SaveChanges();

            return this.Created("PostNews",news);
        }

        //PUT /api/news/{id}
        [HttpPut]
        [Route("api/news/{id}")]
        public IHttpActionResult UpdateNews(int id, [FromBody] NewsBindingModel m)
        {
            if (!Data.News.All().Any(n => n.Id == id))
                return BadRequest("News with the Id specified doesnt exist.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (m.Title == null || m.Content == null)
                return BadRequest();

            var news = Data.News.All().First(n => n.Id == id);

            news.Title = m.Title;
            news.Content = m.Content;
            news.PublishDate = m.PublishedOn;

            Data.SaveChanges();

            return Ok(news);
        }

        //DELETE /api/news/{id}
        [HttpDelete]
        [Route("api/news/{id}")]
        public IHttpActionResult DeleteNews(int id)
        {
            if (!Data.News.All().Any(n => n.Id == id))
                return BadRequest("News with the Id specified doesnt exist.");

            var news = Data.News.All().First(n => n.Id == id);

            Data.News.Delete(news);

            Data.SaveChanges();

            return Ok("Entity deleted successfully.");
        }
    }
}