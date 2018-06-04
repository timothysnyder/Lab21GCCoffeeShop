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

        public ActionResult Admin()
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

        public ActionResult AddItemDetails()
        {
            return View();
        }

        public ActionResult AddNewItem(Item NewItem)
        {
            // 1. Create the ORM
            Coffee_Shop_DBEntities ORM = new Coffee_Shop_DBEntities();

            ORM.Items.Add(NewItem);

            // 4. Save Changes to the Database
            ORM.SaveChanges();

            return RedirectToAction("Admin");
        }

        public ActionResult EditItemDetails(string Name)
        {
            Coffee_Shop_DBEntities ORM = new Coffee_Shop_DBEntities();

            ViewBag.Item = ORM.Items.Find(Name);
            ORM.SaveChanges();

            return View();

        }

        public ActionResult SaveUpdatedItem(Item updatedItem)
        {
            //1. Create the ORM
            Coffee_Shop_DBEntities ORM = new Coffee_Shop_DBEntities();
            //2. Find the  
            Item OldItemRecord = ORM.Items.Find(updatedItem.Name);
            //  Validation
            if (OldItemRecord != null && ModelState.IsValid)
            {
                //3. Update the existing customer

                OldItemRecord.Name = updatedItem.Name;
                OldItemRecord.Description = updatedItem.Description;

                // flip state to "modified"
                ORM.Entry(OldItemRecord).State = System.Data.Entity.EntityState.Modified;

                // 4. Save back to the Database 
                ORM.SaveChanges();
                return RedirectToAction("EditItemDetails");
            }
            else
            {      
                    ViewBag.ErrorMessage = "Oops! Something went wrong!";
                    return View("Error");
            }
        }
    }
}