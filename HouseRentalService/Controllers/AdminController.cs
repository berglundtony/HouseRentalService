using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HouseRentalService;
using HouseRentalService.Models;

namespace HouseRentalService.Controllers
{
    public class AdminController : Controller
    {
        private HouseRentalServiceEntities db = new HouseRentalServiceEntities();

        // GET: Admin
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                var houses = db.Houses.Include(h => h.Price);
                return View(houses.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                House house = db.Houses.Find(id);
                if (house == null)
                {
                    return HttpNotFound();
                }
                return View(house);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var username = "admin";
                var password = "password";
                user.UserId = 1;

                if (user.Username.Trim().ToLower() == username && user.Password.Trim().ToLower() == password)
                {
                    Session["UserID"] = user.UserId.ToString();
                    Session["UserName"] = user.Username.ToString();

                    using (db)
                    {
                        Price prices = db.Prices.FirstOrDefault();
                        IQueryable<double?> basedayfee = db.Prices.Select(x => x.BaseDayFee);
             
                        if (basedayfee.Any())
                        {
                            return RedirectToAction("CreateHouse");
                        }
                        else
                        {
                            return RedirectToAction("CreatePrise");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The username or password was incorrect.");
                }
            }
            return View(user);
        }

        public ActionResult CreatePrice()
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePrice([Bind(Include = "PriceID, BaseDayFee")]Price price)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Prices.Add(price);
                    db.SaveChanges();
                    return RedirectToAction("CreateHouse");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            }

            return View();
        }
        // GET: Admin/EditPrice/5
        public ActionResult EditPrice(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Price price = db.Prices.Find(id);
                if (price == null)
                {
                    return HttpNotFound();
                }
                return View(price);
            }
            else
            {
                return RedirectToAction("Login");
            }  
        }
        // POST: Admin/EditPrice/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPrice([Bind(Include = "PriceID,Type,MultiplicationValue")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PriceID = new SelectList(db.Prices, "PriceID", "PriceID", price.PriceID);
            return View(price);
        }


        // GET: Admin/Create
        public ActionResult CreateHouse()
        {
            if (Session["UserID"] != null)
            {
                CreateHouse housemodel = new CreateHouse();
                housemodel.BaseDayFee = (from d in db.Prices select d.BaseDayFee).FirstOrDefault();
                housemodel.PriceID = (from d in db.Prices select d.PriceID).FirstOrDefault();
                return View(housemodel);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHouse([Bind(Include = "HouseID,PriceID,Type,MultiplicationValue")] CreateHouse house)
        {
            if (ModelState.IsValid)
            {
                House model = new House();
                model.PriceID = house.PriceID;
                model.Type = house.Type;
                model.MultiplicationValue = house.MultiplicationValue;
                db.Houses.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(house);
        }

        // GET: Admin/EditHouse/5
        public ActionResult EditHouse(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                House house = db.Houses.Find(id);
                if (house == null)
                {
                    return HttpNotFound();
                }
                return View(house);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        // POST: Admin/EditHouse/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHouse([Bind(Include = "HouseID,PriceID,Type,MultiplicationValue")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PriceID = new SelectList(db.Prices, "PriceID", "PriceID", house.PriceID);
            return View(house);
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteHouse(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                House house = db.Houses.Find(id);
                if (house == null)
                {
                    return HttpNotFound();
                }
                return View(house);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("DeleteHouse")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
