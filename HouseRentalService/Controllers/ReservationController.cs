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
using HouseRentalService.Functions;

namespace HouseRentalService.Controllers
{
    public class ReservationController : Controller
    {
        private HouseRentalServiceEntities db = new HouseRentalServiceEntities();

        // GET: Reservation
        public ActionResult Index()
        {
            var model = new ReservationModel();
            model._resarvationData = FunctionReservation.GetDataForReservations();
            return View(model._resarvationData);
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = new ReservationModel();
            model = FunctionReservation.GetDetailForReservation(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        // GET: Reservation/CheckPersonalNumber
        public ActionResult CheckPersonalNumber()
        {
            var model = new CheckCustomer();
            return View(model);
        }
        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckPersonalNumber(CheckCustomer customer)
        {
            if (ModelState.IsValid)
            {
                Customer entity = new Customer();
                try
                {  
                    entity = (from c in db.Customers where c.PersonalNumber.Equals(customer.PersonalNumber) select c).FirstOrDefault();
                    return RedirectToAction("CreateReservation", "Reservation", new { CustomerID = entity.CustomerID });
                }
                catch (Exception)
                {
                    return RedirectToAction("CreateCustomer", "Customers", new { Message = "This customer don't seem to be in the system please register and try again." });
                }
            }
            ModelState.AddModelError("", "You didn't typed the personal number in the right way, try again!");
            return View();
        }
        // GET: Reservation/Create
        public ActionResult CreateReservation(int? customerid)
        {
            var model = new MakeReservation();
            if(customerid != null)
            {
                model.CustomerID = customerid;
                model.DropdownHouseType = FunctionReservation.GetHouses();

                return View(model);
            }
            else
            {
               return RedirectToAction("CheckPersonalNumber");
            }
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReservation([Bind(Include = "HouseID,CustomerID,NumberOfDays,Date")] MakeReservation reservation)
        {
            ModelState.Remove("HouseType");
            ModelState.Remove("PersonalNumber");
            ModelState.Remove("ReservationID");
            ModelState.Remove("Fullname");
            reservation.DropdownHouseType = FunctionReservation.GetHouses();

            if (ModelState.IsValid)
            {
                Reservation model = new Reservation();
                ResarvationCustomerConnection connect = new ResarvationCustomerConnection();
                model.HouseID = reservation.HouseID;
                model.CustomerID = reservation.CustomerID;
                model.NumberOfDays = reservation.NumberOfDays;
                model.Date = reservation.Date;
                connect.CustomerID = reservation.CustomerID;
                connect.ResarvationID = reservation.ReservationID;
                db.Reservations.Add(model);
                db.ResarvationCustomerConnections.Add(connect);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(reservation);
        }

        // GET: Reservation/Edit/5
        public ActionResult EditReservation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeReservation model = new MakeReservation();
            model = FunctionReservation.GetEditDetailForReservation(id);
            model.DropdownHouseType = FunctionReservation.GetHouses(model.HouseID);
            if (model == null)
            {
                return HttpNotFound(model.Message);
            }
            return View(model);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReservation([Bind(Include = "ReservationID,HouseID,CustomerID,NumberOfDays,Date")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        // GET: Reservation/Delete/5
        public ActionResult DeleteReservation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("DeleteReservation")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            int conid = db.ResarvationCustomerConnections.Where(x => x.ResarvationID == id).First().ID;
            ResarvationCustomerConnection connection = db.ResarvationCustomerConnections.Find(conid);
            db.ResarvationCustomerConnections.Remove(connection);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
