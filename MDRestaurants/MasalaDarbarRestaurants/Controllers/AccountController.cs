using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasalaDarbarRestaurants.Models;
namespace MasalaDarbarRestaurants.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CustomerDetail account)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())

                if (db.customerDetails.Any(x => x.Username == account.Username))
                {
                    ModelState.AddModelError("Username", "Username is already exist!");

                }
            if (ModelState.IsValid)
            {
                using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
                {
                    db.customerDetails.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = " Thank you! You are Successfully Registered! with Masala Darbar Restaurants";
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerDetail user)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                var usr = db.customerDetails.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("UserHomePage");

                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect");
                }
            }
            return View();

        }

        public ActionResult UserHomePage()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("Username");
            return RedirectToAction("index", "Home");
        }
    }
}