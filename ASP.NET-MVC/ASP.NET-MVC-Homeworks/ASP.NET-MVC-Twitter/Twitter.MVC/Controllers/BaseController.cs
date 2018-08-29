using System.Web.Mvc;
using ASP.NET_MVC_Twitter.Data;

namespace Twitter.MVC.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
            : this(new TwitterContext())
        {
        }

        public BaseController(TwitterContext data)
        {
            this.Data = data;
        }

        protected TwitterContext Data { get; set; }
    }
}