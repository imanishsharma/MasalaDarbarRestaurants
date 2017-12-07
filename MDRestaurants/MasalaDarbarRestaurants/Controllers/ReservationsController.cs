using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasalaDarbarRestaurants.Models;
namespace MasalaDarbarRestaurants.Controllers
{
    public class ReservationsController : Controller
    {
        // GET: Reservations
        public ActionResult MakeReservations()
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                List<string> locations = (from s in db.branchesDetails select s.Location).ToList();
                ViewBag.BLocations = new SelectList(locations);
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult MakeReservations(Reservations Bdetails)
        {
                if (ModelState.IsValid)
                {

                MasalaDarbarDbContext db = new MasalaDarbarDbContext();
                {
                    db.reservationDetails.Add(Bdetails);
                    db.SaveChanges();

                }
                       
                  }

            return RedirectToAction("TReservations");
        }
        public ActionResult TReservations()
        {
            return View();
        }

    }
        }

