using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileManager;

namespace FinalProject.Controllers
{
    public class RoleController : Controller
    {
        private IFileService roleService;

        public RoleController(IFileService role)
        {
            roleService = role; 
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                if (roleService.Save(role))
                {
                    return View("Success");
                }
                else
                {
                    ModelState.AddModelError("", "Не удалось сохранить роль");

                    return View("Fail");
                }
            }
            else return View("Fail");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int roleid)
        {
            if (roleService.Delete(roleid))
            {
                return View("Success");
            }
            else
            {
                return View("Fail");
            }
        }

        public ActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Get(int roleid)
        {
            Role role = roleService.Get(roleid);

            if (role == null)
            {
                return View("Fail");
            }
            else
            {
                return View();
            }
        }


        public ActionResult GetAll()
        {
            return View(roleService.GetAll());
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
        public ActionResult Edit(Role file)
        {
            return View();
        }
    }
}