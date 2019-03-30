using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HouseRentalService;
using HouseRentalService.Functions;
using HouseRentalService.Models;

namespace HouseRentalService.Controllers
{
    public class CustomersController : Controller
    {
        private HouseRentalServiceEntities db = new HouseRentalServiceEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult CreateCustomer()
        {
            if(Request.QueryString["Message"]!= null)
            {
                ModelState.AddModelError("", Request.QueryString["Message"]);
            }
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer([Bind(Include = "PersonalNumber,FirstName,Lastname,MobileNumber,Email")] CreateCustomer customer)
        {
            if (ModelState.IsValid)
            {
                Customer entity = new Customer();
                entity.PersonalNumber = (from c in db.Customers select c.PersonalNumber).FirstOrDefault();

                if (entity.PersonalNumber == customer.PersonalNumber)
                {
                    ModelState.AddModelError("", "This customer are already in the system please use that customer intead.");
                    return View(customer);
                }
                else
                {
                    entity.PersonalNumber = customer.PersonalNumber;
                    entity.FirstName = customer.FirstName;
                    entity.Lastname = customer.Lastname;
                    entity.MobileNumber = customer.MobileNumber;
                    entity.Email = customer.Email;
                    db.Customers.Add(entity);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            CreateCustomer customermodel = new CreateCustomer();
            customermodel.CustomerID = customer.CustomerID;
            customermodel.PersonalNumber = customer.PersonalNumber;
            customermodel.FirstName = customer.FirstName;
            customermodel.Lastname = customer.Lastname;
            customermodel.MobileNumber = customer.MobileNumber;
            customermodel.Email = customer.Email;

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customermodel);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "CustomerID,PersonalNumber,FirstName,Lastname,MobileNumber,Email")] CreateCustomer customer)
        {
            if (ModelState.IsValid)
            {
                Customer customermodel = new Customer();
                customermodel.CustomerID = customer.CustomerID;
                customermodel.PersonalNumber = customer.PersonalNumber;
                customermodel.FirstName = customer.FirstName;
                customermodel.Lastname = customer.Lastname;
                customermodel.MobileNumber = customer.MobileNumber;
                customermodel.Email = customer.Email;
                db.Entry(customermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("DeleteCustomer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
