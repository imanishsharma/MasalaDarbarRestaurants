using MasalaDarbarRestaurants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasalaDarbarRestaurants.Controllers
{
    public class CustomerController : Controller
    {
        
        public ActionResult ShowMenuItems()
        { 
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                return View(db.menuitemsDetails.ToList());
            }       
        }
     
    }
}