using System.Web.Http;
using System.Web.WebSockets;
using News.Data;

namespace News.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new NewsData(new NewsContext()))
        {
        }

        public BaseApiController(INewsData data)
        {
            Data = data;
        }

        protected INewsData Data { get; set; }
    }
}