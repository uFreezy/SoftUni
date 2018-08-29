using System.Web.Http;
using Antlr.Runtime;

namespace Restaurants.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new Data.RestaurantsContext())
        {
        }

        public BaseApiController(Data.RestaurantsContext data)
        {
            Data = data;
        }

        protected Data.RestaurantsContext Data { get; set; }
    }
}