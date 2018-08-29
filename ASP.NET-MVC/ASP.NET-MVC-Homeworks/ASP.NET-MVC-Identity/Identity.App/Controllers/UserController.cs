namespace Identity.App.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            ViewBag.userId = User.Identity.GetUserId();

            return View("~/Views/User/User.cshtml");
        }
    }
}