namespace Identity.App.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();

            return View("~/Views/Admin/Admin.cshtml");
        }
    }
}