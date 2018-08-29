using System.Web.Http;
using OnlineShop.Data;

namespace OnlineShop.Service.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new OnlineShopContext())
        {
        }

        public BaseApiController(OnlineShopContext data)
        {
            Data = data;
        }

        protected OnlineShopContext Data { get; set; }
    }
}