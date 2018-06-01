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

        public ActionResult Menu()
        {
            Coffee_Shop_DBEntities ORM = new Coffee_Shop_DBEntities();

            ViewBag.ItemList = ORM.Items.ToList();

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

        public ActionResult AddNewUser(User newUser)
        {
            //validation!
            if (ModelState.IsValid)
            {

                // 1. Create the ORM
                Coffee_Shop_DBEntities ORM = new Coffee_Shop_DBEntities();

                // 3. Add the new object to the Customer List

                ORM.Users.Add(newUser);

                // 4. Save Changes to the Database
                ORM.SaveChanges();

                ViewBag.Message = $"Welcome {newUser.UserName}";
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