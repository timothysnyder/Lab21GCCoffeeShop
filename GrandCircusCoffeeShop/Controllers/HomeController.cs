using GrandCircusCoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandCircusCoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Grand Circus Coffee Shop.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Grand Circus Coffee Shop.";

            return View();
        }

        public ActionResult SignUpForm()
        {
            ViewBag.Message = "Join Grand Circus Coffee Club.";

            return View();
        }

        public ActionResult AddNewUser(UserInfo newUser)
        {
            //validation!
            if (ModelState.IsValid)
            {
                ViewBag.Message = $"Welcome {newUser.Username}";
                return View("Confirm");
            }

            // to insert the newUser into the Database!

            else
            {
                ViewBag.Address = Request.UserHostAddress;
                return View("Error");
            }

        }

    }
}