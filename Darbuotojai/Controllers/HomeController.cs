using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Darbuotojai.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Apie Darbuotojai";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Mūsų kontaktai";

            return View();
        }
    }
}