﻿using System.Web.Mvc;

namespace Bookmarks.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}