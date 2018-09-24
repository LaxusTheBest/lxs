using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FileManager;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {                    
            return View();
        }

        public ActionResult About()
        {
            return View("Edit");
        }

        public ActionResult Contact()
        {
            return View("Registration");
        }
    }
}