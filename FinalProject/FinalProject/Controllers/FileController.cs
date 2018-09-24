using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileManager;

namespace FinalProject.Controllers
{
    public class FileController : Controller
    {
        FileRepository fileRepository = new FileRepository();

        //[Authorize(Roles ="Admin, manager, user")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles ="admin, manager, user")]
        public ActionResult Create(File file)
        {
            if (ModelState.IsValid)
            {
                fileRepository.Save(file);
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
                fileRepository.Get(id);

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

            if (fileRepository.Delete(id))
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
            return View(fileRepository.GetAll());
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