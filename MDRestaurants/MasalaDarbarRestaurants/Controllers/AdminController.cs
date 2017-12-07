using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasalaDarbarRestaurants.Models;
using System.Data.Entity;

namespace MasalaDarbarRestaurants.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AddBranches()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBranches(MDBranchList newbranches)
        {
            if (ModelState.IsValid)
            {
                using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
                {
                    db.branchesDetails.Add(newbranches);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Branch is Added Succesfully!";

            }


            return View();
        }

        public ActionResult EditBranches(int id=0)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                MDBranchList branch = db.branchesDetails.Find(id);
                if (branch == null)
                {
                    return HttpNotFound();
                }
                return View(branch);
            }
        }
        [HttpPost]
        public ActionResult EditBranches(MDBranchList branchList)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(branchList).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("MasalaDarbarBranches");
                }
                return View(branchList);
            }
        }



        public ActionResult DeleteBranches(int id = 0)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                MDBranchList branchList = db.branchesDetails.Find(id);
                if (branchList == null)
                {
                    return HttpNotFound();
                }
                return View(branchList);
            }
        }

        [HttpPost, ActionName("DeleteBranches")]
        public ActionResult DeleteBranchConfirmed(int id)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                MDBranchList branchList = db.branchesDetails.Find(id);
                db.branchesDetails.Remove(branchList);
                db.SaveChanges();
                return RedirectToAction("MasalaDarbarBranches");
            }
        }







        public ActionResult MasalaDarbarBranches()
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                return View(db.branchesDetails.ToList());
            }
        }
        public ActionResult AddMenuItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMenuItem(MenuItems menuitemdetails, HttpPostedFileBase File1)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                if (ModelState.IsValid)
                {
                    if(File1 != null && File1.ContentLength > 0)
                    {
                        string ImageName = System.IO.Path.GetFileName(File1.FileName);
                        string ImagePath = Server.MapPath("~/MenuItemImages/" + ImageName);
                        File1.SaveAs(ImagePath);
                        menuitemdetails.ItemImage = ImageName;
                        db.menuitemsDetails.Add(menuitemdetails);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                }
            }
          
            return View();
        }
        public ActionResult MenuItemsList()
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                return View(db.menuitemsDetails.ToList());
            }

        }
        public ActionResult EditItem(int id = 0)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                MenuItems menuitem = db.menuitemsDetails.Find(id);
                if(menuitem == null)
                {
                    return HttpNotFound();
                }
                return View(menuitem);
                    }
               }
      


        [HttpPost]
        public ActionResult EditItem(MenuItems menuitems)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(menuitems).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("MenuItemsList");
                }
                return View(menuitems);
            }
        }

        public ActionResult DeleteItem(int id = 0)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                MenuItems menuitem = db.menuitemsDetails.Find(id);
                if(menuitem == null)
                {
                    return HttpNotFound();
                }
                return View(menuitem);
            }
        }

        [HttpPost, ActionName("DeleteItem")]
        public ActionResult DeleteItemConfirmed(int id)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
                {
                MenuItems menuitem = db.menuitemsDetails.Find(id);
                db.menuitemsDetails.Remove(menuitem);
                db.SaveChanges();
                return RedirectToAction("MenuItemList");
            }
        }

        public ActionResult ShowReservations()
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                return View(db.reservationDetails.ToList());
            }

        }
        [HttpPost]
        public ActionResult CompletedReservations(int id)
        {
            using (MasalaDarbarDbContext db = new MasalaDarbarDbContext())
            {
                Reservations reservations = db.reservationDetails.Find(id);
                db.reservationDetails.Remove(reservations);
                db.SaveChanges();
                return RedirectToAction("ShowReservations");
            }
        }

    }
}