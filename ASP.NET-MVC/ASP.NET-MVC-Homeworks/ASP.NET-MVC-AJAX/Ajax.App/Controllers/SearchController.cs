using System.Linq;
using System.Web.Mvc;
using Ajax.Data;

namespace Ajax.App.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCities(string letters)
        {
            var context = new AjaxContext();

            var cities = context.Cities
                .Where(c => c.CityName.StartsWith(letters))
                .OrderBy(c => c.CityName)
                .Take(5);

            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
}