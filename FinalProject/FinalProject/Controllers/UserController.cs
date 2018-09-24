using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileManager;

namespace FinalProject.Controllers
{
    public class UserController : Controller
    {
        IUserService userService = new UserService(new UserRepository());


        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (userService.Save(user))
                {
                    return View("Success");
                }
                else
                {
                    return View("Fail");
                }
            }

            return View();
        }


        public ActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Get(int id)
        {
            try
            {
                userService.Get(id);

                return View("Got");
            }
            catch (Exception)
            {
                return View("Get-Fail");
            }

        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (userService.Delete(id))
            {
                return View("Success");
            }
            else
            {
                return View("Fail");
            }
        
        }

        public ActionResult GetAll()
        {
            return View(userService.GetAll());
        }


        [HttpPost]
        public ActionResult GetAll(string search)
        {
            return View();
        }


        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(File file)
        {
            return View();
        }

    }
}