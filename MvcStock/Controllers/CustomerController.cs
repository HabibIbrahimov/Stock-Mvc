using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var value = db.TBLCUSTOMERS.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(TBLCUSTOMERS p1)
        {
            db.TBLCUSTOMERS.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var customer = db.TBLCUSTOMERS.Find(id);
            db.TBLCUSTOMERS.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult BringCustomer(int id)
        {
            var cstr = db.TBLCUSTOMERS.Find(id);
            return View("BringCustomer",cstr);
        }
        public ActionResult Update(TBLCUSTOMERS p1)
        {
            var customer = db.TBLCUSTOMERS.Find(p1.CustomerId);
            customer.CustomerName = p1.CustomerName;
            customer.CustomerSurname = p1.CustomerSurname;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}