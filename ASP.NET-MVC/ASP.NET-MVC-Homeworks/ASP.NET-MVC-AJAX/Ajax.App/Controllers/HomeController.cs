using System.Linq;
using System.Web.Mvc;
using Ajax.Data;
using Microsoft.Ajax.Utilities;

namespace Ajax.App.Controllers
{
    public class HomeController : Controller
    {
        //Task 1
        public JsonResult CheckUserName(string username)
        {
            var context = new AjaxContext();

            if (context.Users.Any(u => u.UserName.ToLower() == username.ToLower()))
            {
                return Json(0);
            }

            if (username.IsNullOrWhiteSpace())
            {
                return Json(1);
            }

            return Json(2);
        }

        //Task 2
        public ActionResult Index()
        {
            //Horrible code for the purpose of testing the Ajax.
            var context = new AjaxContext();

            var users = context.Users;

            return View("Index", users);
        }

        //Task 2
        public JsonResult GetUserInfo(string userId)
        {
            var context = new AjaxContext();

            var user = context.Users
                .FirstOrDefault(u => u.Id == userId);

            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}