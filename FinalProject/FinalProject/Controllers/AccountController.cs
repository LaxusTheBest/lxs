using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FileManager;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private static string CookieString = "__AUTH_COOKIE";

        UserRepository userService = new UserRepository();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginmodel)
        {
            if (ModelState.IsValid)
            {                
                User user;

                user = userService.Get(loginmodel.Login, loginmodel.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Login, false);

                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Not found");
                }

            }

            return View(loginmodel);

        }

        private void CreateCookie(User user)
        {
            var ticket = new FormsAuthenticationTicket(1,
                        user.Login,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        false,
                        $"{user.UserID}",
                        FormsAuthentication.FormsCookiePath);

            var encryptTicket = FormsAuthentication.Encrypt(ticket);

            var AuthCookie = new HttpCookie(CookieString)
            {
                Value = encryptTicket,
                Expires = DateTime.Now.AddMinutes(30),
            };

            HttpContext.Response.Cookies.Set(AuthCookie);
        }

        public ActionResult LogOff()
        {
            var cookie = HttpContext.Response.Cookies[CookieString];

            if (cookie != null)
            {
                cookie.Value = string.Empty;
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                if (userService.Save(user))
                {
                    RedirectToAction("Home", "Index");
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при регистрации");
                }
            }

            return View(user);
        }
    }
}