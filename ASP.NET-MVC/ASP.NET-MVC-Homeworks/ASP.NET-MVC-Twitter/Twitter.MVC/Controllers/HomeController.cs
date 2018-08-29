using System.Web.Mvc;

namespace Twitter.MVC.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return this.View("Tweets");
        }
    }
}