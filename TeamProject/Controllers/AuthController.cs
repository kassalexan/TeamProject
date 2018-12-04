using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TeamProject.Controllers
{
    public class AuthController : Controller
    {
        public List<User> users = new List<User>();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }


            if (user.Username == "admin" && user.Password == "admin")
            {
                FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return null;
                //Πρέπει να φτιάξoυμε το μήνυμα για το λάθος username-password
            }

            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignUp()      
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult SignUpSubmit(SignUpVM user)
        {
            bool userAdded = false;
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (userAdded)
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                return View("Register", user);
            }

        }


        }
}