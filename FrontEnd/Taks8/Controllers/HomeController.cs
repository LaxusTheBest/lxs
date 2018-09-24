using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taks8.Controllers
{
    public class HomeController : Controller
    {
        static string[] countries = new string[] { "Croatia", "Rusisa", "Sweden", "Portugalia", "Denmark", "Germany" };

        public ActionResult Index()
        {
            ViewBag.Countries = countries;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Task(string yes)
        {
            if (yes == "yes")
            {
                return View(countries);
            }
            else return View();
        }
    }
}